//----------------------------------------------------------------------------
/// <summary>
///	DBPatientenBemerkung.cs
/// Erstellt am:	20.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;

using PMDS.Global;using PMDS.Data.Patient;
using RBU;
using PMDS.Global.db.Patient;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die Patienten Bemerkung.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBPatientenBemerkung : DBBase, IDBBase
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand_patBemByPatient;
		private System.Data.OleDb.OleDbDataAdapter daPatientenBemerkungByPatient;
		private System.Data.OleDb.OleDbDataAdapter daPatientenBemerkungByID;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private dsPatientenBemerkung  dsPatientenBemerkung1;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBPatientenBemerkung()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPatientenBemerkung));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daPatientenBemerkungByPatient = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand_patBemByPatient = new System.Data.OleDb.OleDbCommand();
            this.daPatientenBemerkungByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsPatientenBemerkung1 = new dsPatientenBemerkung();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientenBemerkung1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // daPatientenBemerkungByPatient
            // 
            this.daPatientenBemerkungByPatient.SelectCommand = this.oleDbSelectCommand_patBemByPatient;
            this.daPatientenBemerkungByPatient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientenBemerkung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Datum", "Datum"),
                        new System.Data.Common.DataColumnMapping("Benutzer", "Benutzer"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("IstDekurs", "IstDekurs"),
                        new System.Data.Common.DataColumnMapping("Patient", "Patient")})});
            // 
            // oleDbSelectCommand_patBemByPatient
            // 
            this.oleDbSelectCommand_patBemByPatient.CommandText = resources.GetString("oleDbSelectCommand_patBemByPatient.CommandText");
            this.oleDbSelectCommand_patBemByPatient.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand_patBemByPatient.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IstDekurs", System.Data.OleDb.OleDbType.Boolean, 1, "IstDekurs")});
            // 
            // daPatientenBemerkungByID
            // 
            this.daPatientenBemerkungByID.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPatientenBemerkungByID.InsertCommand = this.oleDbInsertCommand1;
            this.daPatientenBemerkungByID.SelectCommand = this.oleDbSelectCommand2;
            this.daPatientenBemerkungByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientenBemerkung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("Datum", "Datum"),
                        new System.Data.Common.DataColumnMapping("IstDekurs", "IstDekurs")})});
            this.daPatientenBemerkungByID.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = resources.GetString("oleDbDeleteCommand1.CommandText");
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDPatient", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPatient", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Bemerkung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Bemerkung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Bemerkung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Datum", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Datum", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Datum", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Datum", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IstDekurs", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IstDekurs", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [PatientenBemerkung] ([ID], [IDPatient], [Bemerkung], [IDBenutzer], [" +
                "Datum], [IstDekurs]) VALUES (?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 16, "Datum"),
            new System.Data.OleDb.OleDbParameter("IstDekurs", System.Data.OleDb.OleDbType.Boolean, 0, "IstDekurs")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT        ID, IDPatient, Bemerkung, IDBenutzer, Datum, IstDekurs\r\nFROM       " +
                "     PatientenBemerkung\r\nWHERE        (ID = ?)";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 16, "Datum"),
            new System.Data.OleDb.OleDbParameter("IstDekurs", System.Data.OleDb.OleDbType.Boolean, 0, "IstDekurs"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDPatient", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPatient", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Bemerkung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Bemerkung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Bemerkung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Datum", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Datum", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Datum", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Datum", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IstDekurs", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IstDekurs", System.Data.DataRowVersion.Original, null)});
            // 
            // dsPatientenBemerkung1
            // 
            this.dsPatientenBemerkung1.DataSetName = "dsPatientenBemerkung";
            this.dsPatientenBemerkung1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsPatientenBemerkung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientenBemerkung1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daPatientenBemerkungByID;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen Aufenthalt erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
            ITEM.AddPatientenBemerkungRow(Guid.NewGuid(), Guid.Empty, DateTime.Now,"", 
				"", Guid.Empty,  false , "");
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsPatientenBemerkung.PatientenBemerkungDataTable ITEM
		{
			get	{	return dsPatientenBemerkung1.PatientenBemerkung;	}
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
		/// Bemerkungen für Patienten ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
        public dsPatientenBemerkung alleBemerkungenPatient(Guid id, bool istDekurs, object von, object bis)
		{
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                new dsPatientenBemerkung();
            }

			dsPatientenBemerkung ds = new dsPatientenBemerkung();

            daPatientenBemerkungByPatient.SelectCommand.CommandText  = " SELECT        PatientenBemerkung.ID, PatientenBemerkung.IDPatient, " +
                            " PatientenBemerkung.Datum, Benutzer.Nachname + Benutzer.Vorname AS Benutzer, " +
                            " PatientenBemerkung.Bemerkung, PatientenBemerkung.IDBenutzer, PatientenBemerkung.IstDekurs, " +
                            " Patient.Nachname + Patient.Vorname AS Patient " +
                            " FROM            PatientenBemerkung INNER JOIN " +
                            " Benutzer ON PatientenBemerkung.IDBenutzer = Benutzer.ID INNER JOIN " +
                            " Patient ON PatientenBemerkung.IDPatient = Patient.ID " +
                            " WHERE        (PatientenBemerkung.IDPatient = ?) AND (PatientenBemerkung.IstDekurs = ?) ";
            if (von != null )
            {
                daPatientenBemerkungByPatient.SelectCommand.CommandText += " and PatientenBemerkung.Datum >= ? ";
            }
            if (bis != null)
            {
                daPatientenBemerkungByPatient.SelectCommand.CommandText += " and PatientenBemerkung.Datum <= ? ";
            }
            daPatientenBemerkungByPatient.SelectCommand.CommandText += " ORDER BY PatientenBemerkung.Datum desc ";

			daPatientenBemerkungByPatient.SelectCommand.Parameters[0].Value = id;
            daPatientenBemerkungByPatient.SelectCommand.Parameters[1].Value = istDekurs;

            int nextParValue = 2;

            if (von != null)
            {
                System.Data.OleDb.OleDbParameter par2 =   new System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date , 8, "Datum");
                this.oleDbSelectCommand_patBemByPatient.Parameters.Add(par2);
                daPatientenBemerkungByPatient.SelectCommand.Parameters[nextParValue].Value = (DateTime)von;
                nextParValue += 1;
            }
            if (bis != null)
            {
                System.Data.OleDb.OleDbParameter par3 = new System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 8, "Datum");
                this.oleDbSelectCommand_patBemByPatient.Parameters.Add(par3);
                DateTime datBis = new DateTime(((DateTime)bis).Year, ((DateTime)bis).Month, ((DateTime)bis).Day, 23, 59, 59);
                daPatientenBemerkungByPatient.SelectCommand.Parameters[nextParValue].Value = datBis;
            }

			DataBase.Fill(daPatientenBemerkungByPatient, ds.PatientenBemerkung);
			return ds;
		}
        public bool deleteBemerkung(Guid ID)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DataBase.CONNECTION;
            cmd.CommandText = "Delete PatientenBemerkung   WHERE ID = ? ";
            cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = ID;
            cmd.ExecuteNonQuery();
            return true;
        }
	}
}
