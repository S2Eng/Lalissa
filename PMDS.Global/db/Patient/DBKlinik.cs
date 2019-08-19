//----------------------------------------------------------------------------
/// <summary>
///	DBKlinik.cs
/// Erstellt am:	16.9.2004
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
	/// Datenbankklasse für den Zugriff auf die Klinik-Informationen.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBKlinik : DBBase, IDBBase
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daKlinikByID;
		private System.Data.OleDb.OleDbDataAdapter daKlinikListe;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private dsKlinik dsKlinik1;
        private OleDbDataAdapter daAllKliniken;
        private OleDbCommand oleDbCommand3;
		private System.ComponentModel.Container components = null;




        ////----------------------------------------------------------------------------
        ///// <summary>
        ///// Liefert die Default-KlinikID
        ///// </summary>
        ////----------------------------------------------------------------------------
        public static Guid DefaultID()
        {
            return Guid.Empty;
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBKlinik()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBKlinik));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daKlinikListe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daKlinikByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            this.dsKlinik1 = new PMDS.Global.db.Patient.dsKlinik();
            this.daAllKliniken = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlinik1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Persist Security Info=True;Password=NiwQ" +
    "s21+!;User ID=hl;Initial Catalog=PMDSDev";
            // 
            // daKlinikListe
            // 
            this.daKlinikListe.SelectCommand = this.oleDbSelectCommand1;
            this.daKlinikListe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "IDListe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT")})});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT ID, Bezeichnung AS TEXT FROM Klinik ORDER BY Bezeichnung";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // daKlinikByID
            // 
            this.daKlinikByID.DeleteCommand = this.oleDbDeleteCommand3;
            this.daKlinikByID.InsertCommand = this.oleDbInsertCommand3;
            this.daKlinikByID.SelectCommand = this.oleDbSelectCommand3;
            this.daKlinikByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Klinik", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("MitAerztlicheLeitungJN", "MitAerztlicheLeitungJN"),
                        new System.Data.Common.DataColumnMapping("MitAerztlicheAufsichtJN", "MitAerztlicheAufsichtJN"),
                        new System.Data.Common.DataColumnMapping("MitPflegedienstleitungJN", "MitPflegedienstleitungJN"),
                        new System.Data.Common.DataColumnMapping("MitPaedagischeLeitungJN", "MitPaedagischeLeitungJN"),
                        new System.Data.Common.DataColumnMapping("Einrichtungsleiter", "Einrichtungsleiter"),
                        new System.Data.Common.DataColumnMapping("IDBank", "IDBank"),
                        new System.Data.Common.DataColumnMapping("ZVR", "ZVR"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("EinrichtungsleiterTitel", "EinrichtungsleiterTitel"),
                        new System.Data.Common.DataColumnMapping("EinrichtungsleiterVorname", "EinrichtungsleiterVorname"),
                        new System.Data.Common.DataColumnMapping("ELGA_OID", "ELGA_OID"),
                        new System.Data.Common.DataColumnMapping("ELGA_AuthorSpeciality", "ELGA_AuthorSpeciality")})});
            this.daKlinikByID.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = "DELETE FROM [Klinik] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand3
            // 
            this.oleDbInsertCommand3.CommandText = resources.GetString("oleDbInsertCommand3.CommandText");
            this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("MitAerztlicheLeitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "MitAerztlicheLeitungJN"),
            new System.Data.OleDb.OleDbParameter("MitAerztlicheAufsichtJN", System.Data.OleDb.OleDbType.Boolean, 0, "MitAerztlicheAufsichtJN"),
            new System.Data.OleDb.OleDbParameter("MitPflegedienstleitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "MitPflegedienstleitungJN"),
            new System.Data.OleDb.OleDbParameter("MitPaedagischeLeitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "MitPaedagischeLeitungJN"),
            new System.Data.OleDb.OleDbParameter("Einrichtungsleiter", System.Data.OleDb.OleDbType.VarChar, 0, "Einrichtungsleiter"),
            new System.Data.OleDb.OleDbParameter("IDBank", System.Data.OleDb.OleDbType.Guid, 0, "IDBank"),
            new System.Data.OleDb.OleDbParameter("ZVR", System.Data.OleDb.OleDbType.VarChar, 0, "ZVR"),
            new System.Data.OleDb.OleDbParameter("Bereich", System.Data.OleDb.OleDbType.VarChar, 0, "Bereich"),
            new System.Data.OleDb.OleDbParameter("EinrichtungsleiterTitel", System.Data.OleDb.OleDbType.VarWChar, 0, "EinrichtungsleiterTitel"),
            new System.Data.OleDb.OleDbParameter("EinrichtungsleiterVorname", System.Data.OleDb.OleDbType.VarWChar, 0, "EinrichtungsleiterVorname"),
            new System.Data.OleDb.OleDbParameter("ELGA_OID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OID"),
            new System.Data.OleDb.OleDbParameter("ELGA_AuthorSpeciality", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_AuthorSpeciality")});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = resources.GetString("oleDbUpdateCommand3.CommandText");
            this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("MitAerztlicheLeitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "MitAerztlicheLeitungJN"),
            new System.Data.OleDb.OleDbParameter("MitAerztlicheAufsichtJN", System.Data.OleDb.OleDbType.Boolean, 0, "MitAerztlicheAufsichtJN"),
            new System.Data.OleDb.OleDbParameter("MitPflegedienstleitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "MitPflegedienstleitungJN"),
            new System.Data.OleDb.OleDbParameter("MitPaedagischeLeitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "MitPaedagischeLeitungJN"),
            new System.Data.OleDb.OleDbParameter("Einrichtungsleiter", System.Data.OleDb.OleDbType.VarChar, 0, "Einrichtungsleiter"),
            new System.Data.OleDb.OleDbParameter("IDBank", System.Data.OleDb.OleDbType.Guid, 0, "IDBank"),
            new System.Data.OleDb.OleDbParameter("ZVR", System.Data.OleDb.OleDbType.VarChar, 0, "ZVR"),
            new System.Data.OleDb.OleDbParameter("Bereich", System.Data.OleDb.OleDbType.VarChar, 0, "Bereich"),
            new System.Data.OleDb.OleDbParameter("EinrichtungsleiterTitel", System.Data.OleDb.OleDbType.VarWChar, 0, "EinrichtungsleiterTitel"),
            new System.Data.OleDb.OleDbParameter("EinrichtungsleiterVorname", System.Data.OleDb.OleDbType.VarWChar, 0, "EinrichtungsleiterVorname"),
            new System.Data.OleDb.OleDbParameter("ELGA_OID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OID"),
            new System.Data.OleDb.OleDbParameter("ELGA_AuthorSpeciality", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_AuthorSpeciality"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsKlinik1
            // 
            this.dsKlinik1.DataSetName = "dsKlinik";
            this.dsKlinik1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsKlinik1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daAllKliniken
            // 
            this.daAllKliniken.SelectCommand = this.oleDbCommand3;
            this.daAllKliniken.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Klinik", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("MitAerztlicheLeitungJN", "MitAerztlicheLeitungJN"),
                        new System.Data.Common.DataColumnMapping("MitAerztlicheAufsichtJN", "MitAerztlicheAufsichtJN"),
                        new System.Data.Common.DataColumnMapping("MitPflegedienstleitungJN", "MitPflegedienstleitungJN"),
                        new System.Data.Common.DataColumnMapping("MitPaedagischeLeitungJN", "MitPaedagischeLeitungJN"),
                        new System.Data.Common.DataColumnMapping("Einrichtungsleiter", "Einrichtungsleiter"),
                        new System.Data.Common.DataColumnMapping("IDBank", "IDBank"),
                        new System.Data.Common.DataColumnMapping("ZVR", "ZVR"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("EinrichtungsleiterTitel", "EinrichtungsleiterTitel"),
                        new System.Data.Common.DataColumnMapping("EinrichtungsleiterVorname", "EinrichtungsleiterVorname"),
                        new System.Data.Common.DataColumnMapping("ELGA_OID", "ELGA_OID"),
                        new System.Data.Common.DataColumnMapping("ELGA_AuthorSpeciality", "ELGA_AuthorSpeciality")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            ((System.ComponentModel.ISupportInitialize)(this.dsKlinik1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung aller Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daAll
		{
			get	{	return daKlinikListe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daKlinikByID;	}
		}

        ////----------------------------------------------------------------------------
        ///// <summary>
        ///// Neue ZusatzGruppe erzeugen.
        ///// </summary>
        ////----------------------------------------------------------------------------
        public override void New()
        {
            // nur 1'ne Klinik
            ITEM.Clear();
            ITEM.AddKlinikRow(DefaultID(), "", Guid.Empty, Guid.Empty, true, false, false, false, "", Guid.Empty, "", "", "", "", "", "");
        }
        public  bool loadAllKliniken(PMDS.Global.db.Patient.dsKlinik.KlinikDataTable dtAllKliniken)
        {
            dtAllKliniken.Clear();
            //this.daAllKliniken.SelectCommand.Parameters[0].Value = IDKlinik;
            DataBase.Fill(this.daAllKliniken, dtAllKliniken);
            return true;
        }
        public dsKlinik.KlinikRow loadKlinik(System.Guid IDKlinik,bool doExceptionNoKlinikFound)
        {
            dsKlinik.KlinikDataTable dtAllKliniken = new dsKlinik.KlinikDataTable();
            this.daKlinikByID.SelectCommand.Parameters[0].Value = IDKlinik;
            DataBase.Fill(this.daKlinikByID, dtAllKliniken);
            if (dtAllKliniken.Rows.Count != 1)
            {
                if (doExceptionNoKlinikFound)
                    throw new Exception("loadKlinik: dtAllKliniken.Rows.Count != 1 for IDKlinik '" + IDKlinik.ToString() + "'!");
                else
                    return null;
            }
            return (dsKlinik.KlinikRow)dtAllKliniken.Rows[0];
        }

        public bool deletKlinik(dsKlinik.KlinikRow rKlinik)
        {
            OleDbCommand cmd = new OleDbCommand();

            DBAbteilung DBAbteilung1 = new DBAbteilung();
            dsAbteilung dsAbteilung1 = new dsAbteilung();
            DBAbteilung1.getAbteilungenByKlinik(rKlinik.ID, dsAbteilung1);
            foreach (dsAbteilung.AbteilungRow rAbteilung in dsAbteilung1.Abteilung)
            {
                DBKlinikBereiche DBKlinikBereiche1 = new DBKlinikBereiche();
                dsBereich .BereichDataTable tBereicheAbteilung = DBKlinikBereiche1.ByAbteilung(rAbteilung.ID);
                foreach (dsBereich.BereichRow rBereich in tBereicheAbteilung)
                {
                    cmd = new OleDbCommand();
                    if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                        RBU.DataBase.CONNECTION.Open();
                    cmd.Connection = RBU.DataBase.CONNECTION;
                    cmd.CommandTimeout  = 180;
                    cmd.CommandText = " Delete from  Bereich  WHERE ID = ? ";
                    cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = rBereich.ID;
                    cmd.ExecuteNonQuery();
                }

                cmd = new OleDbCommand();
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTION;
                cmd.CommandTimeout = 180;
                cmd.CommandText = " Delete from  Abteilung  WHERE ID = ? ";
                cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = rAbteilung.ID;
                cmd.ExecuteNonQuery();
            }

            cmd = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmd.Connection = RBU.DataBase.CONNECTION;
            cmd.CommandTimeout = 180;
            cmd.CommandText = " Delete from  Klinik  WHERE ID = ? ";
            cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = rKlinik.ID;
            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmd.Connection = RBU.DataBase.CONNECTION;
            cmd.CommandTimeout = 180;
            cmd.CommandText = " Delete from  Bank  WHERE ID = ? ";
            cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = rKlinik.IDBank;
            cmd.ExecuteNonQuery();

            return true;
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsKlinik.KlinikDataTable ITEM
		{
			get	{	return dsKlinik1.Klinik;	}
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
