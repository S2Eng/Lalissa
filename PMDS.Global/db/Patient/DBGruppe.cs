//----------------------------------------------------------------------------
/// <summary>
///	DBGruppe.cs
/// Erstellt am:	11.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;

using RBU;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using System.Collections.Generic;

using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die Gruppe (Rechteverwaltung).
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBGruppe : DBBaseEntries, IDBBaseEntries
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daGruppeByID;
		private System.Data.OleDb.OleDbDataAdapter daGruppeListe;
		private System.Data.OleDb.OleDbDataAdapter daRechtByGruppe;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        private PMDS.Global.db.Patient.dsGruppe dsGruppe1;
        private dsGruppenRecht dsGruppenRecht1;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbDataAdapter daRechtByID;
        private System.Data.OleDb.OleDbCommand cRechteByBenutzer;
        private OleDbDataAdapter daRechteByUser;
        private OleDbCommand oleDbCommand2;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBGruppe()
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
            this.daGruppeByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daGruppeListe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daRechtByGruppe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.dsGruppe1 = new PMDS.Global.db.Patient.dsGruppe();
            this.dsGruppenRecht1 = new dsGruppenRecht();
            this.daRechtByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.cRechteByBenutzer = new System.Data.OleDb.OleDbCommand();
            this.daRechteByUser = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsGruppe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGruppenRecht1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // daGruppeByID
            // 
            this.daGruppeByID.DeleteCommand = this.oleDbDeleteCommand1;
            this.daGruppeByID.InsertCommand = this.oleDbInsertCommand1;
            this.daGruppeByID.SelectCommand = this.oleDbSelectCommand1;
            this.daGruppeByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Gruppe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})});
            this.daGruppeByID.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM Gruppe WHERE (ID = ?)";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO Gruppe(ID, Bezeichnung) VALUES (?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 255, "Bezeichnung")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT ID, Bezeichnung FROM Gruppe WHERE (ID = ?)";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE Gruppe SET ID = ?, Bezeichnung = ? WHERE (ID = ?)";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 255, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daGruppeListe
            // 
            this.daGruppeListe.SelectCommand = this.oleDbSelectCommand2;
            this.daGruppeListe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "IDListe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT")})});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT ID, Bezeichnung AS TEXT FROM Gruppe ORDER BY Bezeichnung";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            // 
            // daRechtByGruppe
            // 
            this.daRechtByGruppe.DeleteCommand = this.oleDbDeleteCommand2;
            this.daRechtByGruppe.InsertCommand = this.oleDbInsertCommand2;
            this.daRechtByGruppe.SelectCommand = this.oleDbSelectCommand3;
            this.daRechtByGruppe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GruppenRecht", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDGruppe", "IDGruppe"),
                        new System.Data.Common.DataColumnMapping("IDRecht", "IDRecht")})});
            this.daRechtByGruppe.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM GruppenRecht WHERE (IDGruppe = ?) AND (IDRecht = ?)";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDGruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDRecht", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDRecht", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO GruppenRecht(IDGruppe, IDRecht) VALUES (?, ?)";
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, "IDGruppe"),
            new System.Data.OleDb.OleDbParameter("IDRecht", System.Data.OleDb.OleDbType.Integer, 4, "IDRecht")});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT IDGruppe, IDRecht FROM GruppenRecht WHERE (IDGruppe = ?)";
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, "IDGruppe")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = "UPDATE GruppenRecht SET IDGruppe = ?, IDRecht = ? WHERE (IDGruppe = ?) AND (IDRec" +
    "ht = ?)";
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, "IDGruppe"),
            new System.Data.OleDb.OleDbParameter("IDRecht", System.Data.OleDb.OleDbType.Integer, 4, "IDRecht"),
            new System.Data.OleDb.OleDbParameter("Original_IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDGruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDRecht", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDRecht", System.Data.DataRowVersion.Original, null)});
            // 
            // dsGruppe1
            // 
            this.dsGruppe1.DataSetName = "dsGruppe";
            this.dsGruppe1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsGruppe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsGruppenRecht1
            // 
            this.dsGruppenRecht1.DataSetName = "dsGruppenRecht";
            this.dsGruppenRecht1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsGruppenRecht1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daRechtByID
            // 
            this.daRechtByID.SelectCommand = this.oleDbCommand1;
            this.daRechtByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "INTListe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "TEXT")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "SELECT ID, Bezeichnung FROM Recht WHERE (ID = ?)";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Integer, 4, "ID")});
            // 
            // cRechteByBenutzer
            // 
            this.cRechteByBenutzer.CommandText = "SELECT GruppenRecht.IDRecht FROM GruppenRecht INNER JOIN BenutzerGruppe ON Gruppe" +
    "nRecht.IDGruppe = BenutzerGruppe.IDGruppe WHERE (BenutzerGruppe.IDBenutzer = ?) " +
    "ORDER BY GruppenRecht.IDRecht";
            this.cRechteByBenutzer.Connection = this.oleDbConnection1;
            this.cRechteByBenutzer.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer")});
            // 
            // daRechteByUser
            // 
            this.daRechteByUser.SelectCommand = this.oleDbCommand2;
            this.daRechteByUser.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GruppenRecht", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDRecht", "IDRecht")})});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "SELECT GruppenRecht.IDRecht FROM GruppenRecht INNER JOIN BenutzerGruppe ON Gruppe" +
    "nRecht.IDGruppe = BenutzerGruppe.IDGruppe WHERE (BenutzerGruppe.IDBenutzer = ?) " +
    "ORDER BY GruppenRecht.IDRecht";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer")});
            ((System.ComponentModel.ISupportInitialize)(this.dsGruppe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGruppenRecht1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung aller Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daAll
		{
			get	{	return daGruppeListe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daGruppeByID;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung der Sub-Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daSubEntries
		{
			get	{	return daRechtByGruppe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neue Eintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
			ITEM.AddGruppeRow(Guid.NewGuid(), "");
			SUBITEMS.Clear();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen SubEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsGruppenRecht.GruppenRechtRow NewEntry()
		{
			return SUBITEMS.AddGruppenRechtRow(ITEM[0].ID, -1);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsGruppe.GruppeDataTable ITEM
		{
			get	{	return dsGruppe1.Gruppe;	}
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert alle Benutzer welche der übergebenen Gruppe angehören
        /// </summary>
        //----------------------------------------------------------------------------
        public static List<Guid> GetAllBenutzer(Guid IDGruppe)
        {
            try
            {
                List<Guid> al = new List<Guid>();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "Select IDBenutzer from BenutzerGruppe where IDGruppe = ?";
                cmd.Parameters.AddWithValue("IDGruppe", IDGruppe);
                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                foreach (System.Data.DataRow r in dtSelect.Rows)
                {
                    Guid idGuid = new Guid(r[0].ToString());
                    al.Add(idGuid);
                }

                return al;

            }
            catch (Exception ex)
            {
                throw new Exception("GetAllBenutzer: " + ex.ToString());
            }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsGruppenRecht.GruppenRechtDataTable SUBITEMS
		{
			get	{	return dsGruppenRecht1.GruppenRecht;	}
		}

		#region IDBBase & IDBBaseEntries Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		DataTable IDBBase.ITEM
		{
			get	{	return this.ITEM;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen SubEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		DataRow IDBBaseEntries.NewEntry()
		{
			return this.NewEntry();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		DataTable IDBBaseEntries.SUBITEMS
		{
			get	{	return this.SUBITEMS;	}
		}

		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Alle Rechte ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public dsINTListe.INTListeDataTable AlleRechte()
		{
			dsINTListe ds = new dsINTListe();
            if (!DesignMode)
            {
                // nur bekannte Rechte ermitteln
                foreach (int e in Enum.GetValues(typeof(UserRights)))
                {
                    daRechtByID.SelectCommand.Parameters[0].Value = e;
                    DBUtil.OneRowByID(this, ds.INTListe, daRechtByID, DesignMode);
                }
            }
			return ds.INTListe;
		}

        public PMDS.Global.db.Patient.dsGruppe.GruppeRow readGruppe(Guid IDGruppe, bool NoExceptionNothingFound)
        {
            dsGruppe ds = new dsGruppe();
            daGruppeByID.SelectCommand.Parameters[0].Value = IDGruppe;
            DataBase.Fill(daGruppeByID, ds);
            if (NoExceptionNothingFound)
            {
                if (ds.Gruppe.Rows.Count > 0)
                {
                    return (dsGruppe.GruppeRow)ds.Gruppe.Rows[0];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return (dsGruppe.GruppeRow)ds.Gruppe.Rows[0];
            }
          
        }
		//----------------------------------------------------------------------------
		/// <summary>
		/// Rechte für Benutzer ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
        public PMDS.Global.db.Patient.dsGruppe ByBenutzer(Guid id)
		{
            PMDS.Global.db.Patient.dsGruppe ds = new PMDS.Global.db.Patient.dsGruppe();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            this.daRechteByUser.SelectCommand.Connection = RBU.DataBase.CONNECTION;
            this.daRechteByUser.SelectCommand.Parameters[0].Value = id;
            this.daRechteByUser.Fill(ds.GruppenRecht);
            return ds;
		}
	}
}
