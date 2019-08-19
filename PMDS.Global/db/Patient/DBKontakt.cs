//----------------------------------------------------------------------------
/// <summary>
///	DBkontakt.cs
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
	/// Datenbankklasse für den Zugriff auf die Kontaktinformationen.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBKontakt : DBBase, IDBBase
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daKontaktById;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        public dsKontakt dsKontakt1;
        public OleDbDataAdapter daKontakteWhere;
        private OleDbCommand oleDbCommand1;
        private OleDbCommand oleDbCommand2;
        private OleDbCommand oleDbCommand3;
        private OleDbCommand oleDbCommand4;
        private System.ComponentModel.Container components = null;


        public string sSelKontakteWhere = "";



        //----------------------------------------------------------------------------
        /// <summary>
        /// Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public DBKontakt()
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
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daKontaktById = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsKontakt1 = new PMDS.Global.db.Patient.dsKontakt();
            this.daKontakteWhere = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsKontakt1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=192.168.80.210;Integrated Security=SSPI;Initial Ca" +
    "talog=PMDSDev";
            // 
            // daKontaktById
            // 
            this.daKontaktById.DeleteCommand = this.oleDbDeleteCommand1;
            this.daKontaktById.InsertCommand = this.oleDbInsertCommand1;
            this.daKontaktById.SelectCommand = this.oleDbSelectCommand1;
            this.daKontaktById.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Kontakt", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Tel", "Tel"),
                        new System.Data.Common.DataColumnMapping("Fax", "Fax"),
                        new System.Data.Common.DataColumnMapping("Mobil", "Mobil"),
                        new System.Data.Common.DataColumnMapping("Andere", "Andere"),
                        new System.Data.Common.DataColumnMapping("Email", "Email"),
                        new System.Data.Common.DataColumnMapping("Ansprechpartner", "Ansprechpartner"),
                        new System.Data.Common.DataColumnMapping("Zusatz1", "Zusatz1"),
                        new System.Data.Common.DataColumnMapping("Zusatz2", "Zusatz2"),
                        new System.Data.Common.DataColumnMapping("Zusatz3", "Zusatz3")})});
            this.daKontaktById.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM Kontakt WHERE (ID = ?)";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO Kontakt(ID, Tel, Fax, Mobil, Andere, Email, Ansprechpartner, Zusatz1," +
    " Zusatz2, Zusatz3) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("Tel", System.Data.OleDb.OleDbType.VarChar, 25, "Tel"),
            new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarChar, 25, "Fax"),
            new System.Data.OleDb.OleDbParameter("Mobil", System.Data.OleDb.OleDbType.VarChar, 25, "Mobil"),
            new System.Data.OleDb.OleDbParameter("Andere", System.Data.OleDb.OleDbType.VarChar, 25, "Andere"),
            new System.Data.OleDb.OleDbParameter("Email", System.Data.OleDb.OleDbType.VarChar, 50, "Email"),
            new System.Data.OleDb.OleDbParameter("Ansprechpartner", System.Data.OleDb.OleDbType.VarChar, 50, "Ansprechpartner"),
            new System.Data.OleDb.OleDbParameter("Zusatz1", System.Data.OleDb.OleDbType.VarChar, 75, "Zusatz1"),
            new System.Data.OleDb.OleDbParameter("Zusatz2", System.Data.OleDb.OleDbType.VarChar, 75, "Zusatz2"),
            new System.Data.OleDb.OleDbParameter("Zusatz3", System.Data.OleDb.OleDbType.VarChar, 75, "Zusatz3")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT ID, Tel, Fax, Mobil, Andere, Email, Ansprechpartner, Zusatz1, Zusatz2, Zus" +
    "atz3 FROM Kontakt WHERE (ID = ?)";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE Kontakt SET ID = ?, Tel = ?, Fax = ?, Mobil = ?, Andere = ?, Email = ?, An" +
    "sprechpartner = ?, Zusatz1 = ?, Zusatz2 = ?, Zusatz3 = ? WHERE (ID = ?)";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("Tel", System.Data.OleDb.OleDbType.VarChar, 25, "Tel"),
            new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarChar, 25, "Fax"),
            new System.Data.OleDb.OleDbParameter("Mobil", System.Data.OleDb.OleDbType.VarChar, 25, "Mobil"),
            new System.Data.OleDb.OleDbParameter("Andere", System.Data.OleDb.OleDbType.VarChar, 25, "Andere"),
            new System.Data.OleDb.OleDbParameter("Email", System.Data.OleDb.OleDbType.VarChar, 50, "Email"),
            new System.Data.OleDb.OleDbParameter("Ansprechpartner", System.Data.OleDb.OleDbType.VarChar, 50, "Ansprechpartner"),
            new System.Data.OleDb.OleDbParameter("Zusatz1", System.Data.OleDb.OleDbType.VarChar, 75, "Zusatz1"),
            new System.Data.OleDb.OleDbParameter("Zusatz2", System.Data.OleDb.OleDbType.VarChar, 75, "Zusatz2"),
            new System.Data.OleDb.OleDbParameter("Zusatz3", System.Data.OleDb.OleDbType.VarChar, 75, "Zusatz3"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsKontakt1
            // 
            this.dsKontakt1.DataSetName = "dsKontakt";
            this.dsKontakt1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsKontakt1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daKontakteWhere
            // 
            this.daKontakteWhere.DeleteCommand = this.oleDbCommand1;
            this.daKontakteWhere.InsertCommand = this.oleDbCommand2;
            this.daKontakteWhere.SelectCommand = this.oleDbCommand3;
            this.daKontakteWhere.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Kontakt", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Tel", "Tel"),
                        new System.Data.Common.DataColumnMapping("Fax", "Fax"),
                        new System.Data.Common.DataColumnMapping("Mobil", "Mobil"),
                        new System.Data.Common.DataColumnMapping("Andere", "Andere"),
                        new System.Data.Common.DataColumnMapping("Email", "Email"),
                        new System.Data.Common.DataColumnMapping("Ansprechpartner", "Ansprechpartner"),
                        new System.Data.Common.DataColumnMapping("Zusatz1", "Zusatz1"),
                        new System.Data.Common.DataColumnMapping("Zusatz2", "Zusatz2"),
                        new System.Data.Common.DataColumnMapping("Zusatz3", "Zusatz3")})});
            this.daKontakteWhere.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [Kontakt] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "INSERT INTO [Kontakt] ([ID], [Tel], [Fax], [Mobil], [Andere], [Email], [Ansprechp" +
    "artner], [Zusatz1], [Zusatz2], [Zusatz3]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Tel", System.Data.OleDb.OleDbType.VarChar, 0, "Tel"),
            new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarChar, 0, "Fax"),
            new System.Data.OleDb.OleDbParameter("Mobil", System.Data.OleDb.OleDbType.VarChar, 0, "Mobil"),
            new System.Data.OleDb.OleDbParameter("Andere", System.Data.OleDb.OleDbType.VarChar, 0, "Andere"),
            new System.Data.OleDb.OleDbParameter("Email", System.Data.OleDb.OleDbType.VarChar, 0, "Email"),
            new System.Data.OleDb.OleDbParameter("Ansprechpartner", System.Data.OleDb.OleDbType.VarChar, 0, "Ansprechpartner"),
            new System.Data.OleDb.OleDbParameter("Zusatz1", System.Data.OleDb.OleDbType.VarChar, 0, "Zusatz1"),
            new System.Data.OleDb.OleDbParameter("Zusatz2", System.Data.OleDb.OleDbType.VarChar, 0, "Zusatz2"),
            new System.Data.OleDb.OleDbParameter("Zusatz3", System.Data.OleDb.OleDbType.VarChar, 0, "Zusatz3")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT        ID, Tel, Fax, Mobil, Andere, Email, Ansprechpartner, Zusatz1, Zusat" +
    "z2, Zusatz3\r\nFROM            Kontakt";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "UPDATE [Kontakt] SET [ID] = ?, [Tel] = ?, [Fax] = ?, [Mobil] = ?, [Andere] = ?, [" +
    "Email] = ?, [Ansprechpartner] = ?, [Zusatz1] = ?, [Zusatz2] = ?, [Zusatz3] = ? W" +
    "HERE (([ID] = ?))";
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Tel", System.Data.OleDb.OleDbType.VarChar, 0, "Tel"),
            new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarChar, 0, "Fax"),
            new System.Data.OleDb.OleDbParameter("Mobil", System.Data.OleDb.OleDbType.VarChar, 0, "Mobil"),
            new System.Data.OleDb.OleDbParameter("Andere", System.Data.OleDb.OleDbType.VarChar, 0, "Andere"),
            new System.Data.OleDb.OleDbParameter("Email", System.Data.OleDb.OleDbType.VarChar, 0, "Email"),
            new System.Data.OleDb.OleDbParameter("Ansprechpartner", System.Data.OleDb.OleDbType.VarChar, 0, "Ansprechpartner"),
            new System.Data.OleDb.OleDbParameter("Zusatz1", System.Data.OleDb.OleDbType.VarChar, 0, "Zusatz1"),
            new System.Data.OleDb.OleDbParameter("Zusatz2", System.Data.OleDb.OleDbType.VarChar, 0, "Zusatz2"),
            new System.Data.OleDb.OleDbParameter("Zusatz3", System.Data.OleDb.OleDbType.VarChar, 0, "Zusatz3"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsKontakt1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daKontaktById;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen ZusatzEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
			ITEM.AddKontaktRow(Guid.NewGuid(), "", "", "", "", "", "", "", "", "");
		}

        public dsKontakt.KontaktRow loadKontaktKlinik(System.Guid IDKontakt, bool doExceptionNoKlinikFound)
        {
            dsKontakt.KontaktDataTable dtKontaktKlinik = new dsKontakt.KontaktDataTable();
            this.daKontaktById.SelectCommand.Parameters[0].Value = IDKontakt;
            RBU.DataBase.Fill(this.daKontaktById, dtKontaktKlinik);
            if (dtKontaktKlinik.Rows.Count != 1)
            {
                if (doExceptionNoKlinikFound)
                    throw new Exception("loadKontaktKlinik: dtKontaktKlinik.Rows.Count != 1 for IDKontakt '" + IDKontakt.ToString() + "'!");
                else
                    return null;
            }
            return (dsKontakt.KontaktRow)dtKontaktKlinik.Rows[0];
        }

        public void loadKontakteWhere(string sWhere, ref dsKontakt.KontaktDataTable dtKontakt)
        {
            if (sSelKontakteWhere.Trim() == "")
                sSelKontakteWhere = this.daKontakteWhere.SelectCommand.CommandText;

            this.daKontakteWhere.SelectCommand.CommandText = sSelKontakteWhere;
            this.daKontakteWhere.SelectCommand.CommandText += sWhere;
            RBU.DataBase.Fill(this.daKontakteWhere, dtKontakt);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// DatenTabelle liefern
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual dsKontakt.KontaktDataTable ITEM
		{
			get	{	return dsKontakt1.Kontakt;	}
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
