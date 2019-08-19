//----------------------------------------------------------------------------
/// <summary>
///	DBZusatzWert.cs
/// Erstellt am:	07.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;

using PMDS.Global;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf ZusatzWerte.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBZusatzWert : DBBase, IDBBase
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daZusatzWertByID;
        public dsZusatzWert dsZusatzWert1;
        private System.Data.OleDb.OleDbCommand cNewZusatzWerte;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        private OleDbDataAdapter daZusatzWertByID2;
        private OleDbCommand oleDbCommand3;
        private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBZusatzWert()
		{
			InitializeComponent();
			IsSingleEntry = false;

			Filter = Guid.Empty;
			Abteilung = Guid.Empty;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBZusatzWert));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daZusatzWertByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsZusatzWert1 = new dsZusatzWert();
            this.cNewZusatzWerte = new System.Data.OleDb.OleDbCommand();
            this.daZusatzWertByID2 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzWert1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Integrated Security=SSPI;Initial Catalog" +
    "=PMDSDev";
            // 
            // daZusatzWertByID
            // 
            this.daZusatzWertByID.DeleteCommand = this.oleDbDeleteCommand2;
            this.daZusatzWertByID.InsertCommand = this.oleDbInsertCommand1;
            this.daZusatzWertByID.SelectCommand = this.oleDbSelectCommand1;
            this.daZusatzWertByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ZusatzWert", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDZusatzGruppeEintrag", "IDZusatzGruppeEintrag"),
                        new System.Data.Common.DataColumnMapping("IDObjekt", "IDObjekt"),
                        new System.Data.Common.DataColumnMapping("Wert", "Wert"),
                        new System.Data.Common.DataColumnMapping("ZahlenWert", "ZahlenWert"),
                        new System.Data.Common.DataColumnMapping("RawFormat", "RawFormat"),
                        new System.Data.Common.DataColumnMapping("ZahlenWertFloat", "ZahlenWertFloat")})});
            this.daZusatzWertByID.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM ZusatzWert WHERE (ID = ?)";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO ZusatzWert(ID, IDZusatzGruppeEintrag, IDObjekt, Wert, ZahlenWert, Raw" +
    "Format, ZahlenWertFloat) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppeEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDZusatzGruppeEintrag"),
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 16, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("Wert", System.Data.OleDb.OleDbType.VarChar, 2147483647, "Wert"),
            new System.Data.OleDb.OleDbParameter("ZahlenWert", System.Data.OleDb.OleDbType.Integer, 4, "ZahlenWert"),
            new System.Data.OleDb.OleDbParameter("RawFormat", System.Data.OleDb.OleDbType.VarBinary, 2147483647, "RawFormat"),
            new System.Data.OleDb.OleDbParameter("ZahlenWertFloat", System.Data.OleDb.OleDbType.Single, 8, "ZahlenWertFloat")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 16, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppe", System.Data.OleDb.OleDbType.VarChar, 6, "IDZusatzGruppe"),
            new System.Data.OleDb.OleDbParameter("IDObjekt1", System.Data.OleDb.OleDbType.Guid, 16, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("IDFilter", System.Data.OleDb.OleDbType.Guid, 16, "IDFilter")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE ZusatzWert SET ID = ?, IDZusatzGruppeEintrag = ?, IDObjekt = ?, Wert = ?, " +
    "ZahlenWert = ?, RawFormat = ?, ZahlenWertFloat = ? WHERE (ID = ?)";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppeEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDZusatzGruppeEintrag"),
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 16, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("Wert", System.Data.OleDb.OleDbType.VarChar, 2147483647, "Wert"),
            new System.Data.OleDb.OleDbParameter("ZahlenWert", System.Data.OleDb.OleDbType.Integer, 4, "ZahlenWert"),
            new System.Data.OleDb.OleDbParameter("RawFormat", System.Data.OleDb.OleDbType.VarBinary, 2147483647, "RawFormat"),
            new System.Data.OleDb.OleDbParameter("ZahlenWertFloat", System.Data.OleDb.OleDbType.Single, 8, "ZahlenWertFloat"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsZusatzWert1
            // 
            this.dsZusatzWert1.DataSetName = "dsZusatzWert";
            this.dsZusatzWert1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsZusatzWert1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cNewZusatzWerte
            // 
            this.cNewZusatzWerte.CommandText = resources.GetString("cNewZusatzWerte.CommandText");
            this.cNewZusatzWerte.Connection = this.oleDbConnection1;
            this.cNewZusatzWerte.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 16, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppe", System.Data.OleDb.OleDbType.VarChar, 6, "IDZusatzGruppe"),
            new System.Data.OleDb.OleDbParameter("IDObjekt1", System.Data.OleDb.OleDbType.Guid, 16, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("IDFilter", System.Data.OleDb.OleDbType.Guid, 16, "IDFilter")});
            // 
            // daZusatzWertByID2
            // 
            this.daZusatzWertByID2.SelectCommand = this.oleDbCommand3;
            this.daZusatzWertByID2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ZusatzWert", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDZusatzGruppeEintrag", "IDZusatzGruppeEintrag"),
                        new System.Data.Common.DataColumnMapping("IDObjekt", "IDObjekt"),
                        new System.Data.Common.DataColumnMapping("Wert", "Wert"),
                        new System.Data.Common.DataColumnMapping("ZahlenWert", "ZahlenWert"),
                        new System.Data.Common.DataColumnMapping("RawFormat", "RawFormat"),
                        new System.Data.Common.DataColumnMapping("ZahlenWertFloat", "ZahlenWertFloat")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT        ID, IDZusatzGruppeEintrag, IDObjekt, Wert, ZahlenWert, RawFormat, Z" +
    "ahlenWertFloat\r\nFROM            ZusatzWert\r\nWHERE        (ID = ?)";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzWert1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Gruppe setzten
		/// </summary>
		//----------------------------------------------------------------------------
		public string Gruppe
		{
			get	{	return (string)daZusatzWertByID.SelectCommand.Parameters[1].Value;	}
			set	{	daZusatzWertByID.SelectCommand.Parameters[1].Value = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Abteilung setzten
		/// </summary>
		//----------------------------------------------------------------------------
		public Guid Abteilung
		{
			get	{	return (Guid)daZusatzWertByID.SelectCommand.Parameters[2].Value;	}
			set	{	daZusatzWertByID.SelectCommand.Parameters[2].Value = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Filter setzten
		/// </summary>
		//----------------------------------------------------------------------------
		public Guid Filter
		{
			get	{	return (Guid)daZusatzWertByID.SelectCommand.Parameters[3].Value;	}
			set	{	daZusatzWertByID.SelectCommand.Parameters[3].Value = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daZusatzWertByID;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Einträge neu lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void Read()
		{
			base.Read();
			AddNewItems();
		}

        public void readByID(Guid ID)
        {
            try
            {
                this.dsZusatzWert1.Clear();
                this.daZusatzWertByID2.SelectCommand.Parameters.Clear();
                this.daZusatzWertByID2.SelectCommand.Parameters.AddWithValue("ID", ID);
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                this.daZusatzWertByID2.SelectCommand.Connection = RBU.DataBase.CONNECTION;
                this.daZusatzWertByID2.Fill(this.dsZusatzWert1.ZusatzWert);

            }
            catch (Exception ex)
            {
                throw new Exception("readByID: " + ex.ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// 11.3.2008: RBU: Leere Zusatzwerte sollen nicht in die DB geschrieben 
        /// werden
        /// </summary>
        //----------------------------------------------------------------------------
        public override void Write()
        {
            dsZusatzWert ds = new dsZusatzWert();
            foreach (dsZusatzWert.ZusatzWertRow r in dsZusatzWert1.ZusatzWert)
            {
                if (r.RowState != DataRowState.Added)
                    continue;

                r.AcceptChanges();      // Die gelöschten und Modifizierten müssen auch geschrieben werden, die Eingefügten werden später behandelt

                if (!r.IsWertNull() && r.Wert.Trim().Length > 0)
                {
                    ds.ZusatzWert.Rows.Add(r.ItemArray);
                    continue;
                }

                if (!r.IsZahlenWertNull() && r.ZahlenWert != -1)
                {
                    ds.ZusatzWert.Rows.Add(r.ItemArray);
                    continue;
                }

                if (!r.IsRawFormatNull() && r.RawFormat.Length > 0)
                {
                    ds.ZusatzWert.Rows.Add(r.ItemArray);
                    continue;
                }

                if (!r.IsZahlenWertFloatNull() && r.ZahlenWertFloat != -1)
                {
                    ds.ZusatzWert.Rows.Add(r.ItemArray);
                    continue;
                }

                
            }

            DataBase.Update(daZusatzWertByID, dsZusatzWert1);           // Updates / deletes verspeichern
            DataBase.Update(daZusatzWertByID, ds);                      // Neue in die DB

        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsZusatzWert.ZusatzWertDataTable ITEM
		{
			get	{	return dsZusatzWert1.ZusatzWert;	}
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

		//----------------------------------------------------------------------------
		/// <summary>
		/// Hängt alle neuen Elemente an
		/// </summary> 
		//----------------------------------------------------------------------------
		private void AddNewItems() 
		{
            try
            {
                // init Command
                cNewZusatzWerte.Parameters[0].Value = ID;
                cNewZusatzWerte.Parameters[1].Value = Gruppe;
                cNewZusatzWerte.Parameters[2].Value = Abteilung;
                cNewZusatzWerte.Parameters[3].Value = Filter;

                //OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cNewZusatzWerte;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                da.SelectCommand.Connection = RBU.DataBase.CONNECTION;
                cNewZusatzWerte.CommandText = cNewZusatzWerte.CommandText;
                DataTable dt = new DataTable();
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dt);
                foreach (DataRow r in dt.Rows)
                {
                    Guid id = (Guid)r[0];
                    ITEM.AddZusatzWertRow(Guid.NewGuid(), id, (Guid)ID, "", -1, new byte[0], -1.0);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("AddNewItems: " + ex.ToString());
            }
		}
	}
}
