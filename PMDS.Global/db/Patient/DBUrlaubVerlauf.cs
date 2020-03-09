using System;
using System.Data;
using System.Data.OleDb;

using RBU;
using PMDS.Global;using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.DB
{
    
	public class DBUrlaubVerlauf : DBBase, IDBBase
	{

		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daUlraubVerlaufByAufenthalt;
        private dsUrlaubVerlauf dsUrlaubVerlauf1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbDataAdapter daUrlaubVerlaufByID;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        private OleDbDataAdapter daAlleUrlaube;
        private OleDbCommand oleDbCommand1;
		private System.ComponentModel.Container components = null;




        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBUrlaubVerlauf));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daUlraubVerlaufByAufenthalt = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsUrlaubVerlauf1 = new dsUrlaubVerlauf();
            this.daUrlaubVerlaufByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daAlleUrlaube = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsUrlaubVerlauf1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // daUlraubVerlaufByAufenthalt
            // 
            this.daUlraubVerlaufByAufenthalt.SelectCommand = this.oleDbSelectCommand1;
            this.daUlraubVerlaufByAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "UrlaubVerlauf", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert")})});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT ID, IDAufenthalt, StartDatum, EndeDatum, Text, IDBenutzer_Erstellt, IDBenu" +
                "tzer_Geaendert, DatumErstellt, DatumGeaendert FROM UrlaubVerlauf WHERE (IDAufent" +
                "halt = ?) ORDER BY StartDatum";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});
            // 
            // dsUrlaubVerlauf1
            // 
            this.dsUrlaubVerlauf1.DataSetName = "dsUrlaubVerlauf";
            this.dsUrlaubVerlauf1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsUrlaubVerlauf1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daUrlaubVerlaufByID
            // 
            this.daUrlaubVerlaufByID.DeleteCommand = this.oleDbDeleteCommand2;
            this.daUrlaubVerlaufByID.InsertCommand = this.oleDbInsertCommand2;
            this.daUrlaubVerlaufByID.SelectCommand = this.oleDbSelectCommand2;
            this.daUrlaubVerlaufByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "UrlaubVerlauf", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert")})});
            this.daUrlaubVerlaufByID.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM UrlaubVerlauf WHERE (ID = ?)";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO UrlaubVerlauf(ID, IDAufenthalt, StartDatum, EndeDatum, Text, IDBenutz" +
                "er_Erstellt, IDBenutzer_Geaendert, DatumErstellt, DatumGeaendert) VALUES (?, ?, " +
                "?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.Date, 8, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.Date, 8, "EndeDatum"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 255, "Text"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 8, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 8, "DatumGeaendert")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT ID, IDAufenthalt, StartDatum, EndeDatum, Text, IDBenutzer_Erstellt, IDBenu" +
                "tzer_Geaendert, DatumErstellt, DatumGeaendert FROM UrlaubVerlauf WHERE (ID = ?)";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = "UPDATE UrlaubVerlauf SET ID = ?, IDAufenthalt = ?, StartDatum = ?, EndeDatum = ?," +
                " Text = ?, IDBenutzer_Erstellt = ?, IDBenutzer_Geaendert = ?, DatumErstellt = ?," +
                " DatumGeaendert = ? WHERE (ID = ?)";
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.Date, 8, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.Date, 8, "EndeDatum"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 255, "Text"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 8, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 8, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daAlleUrlaube
            // 
            this.daAlleUrlaube.SelectCommand = this.oleDbCommand1;
            this.daAlleUrlaube.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "UrlaubVerlauf", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.Date, 8, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("StartDatum1", System.Data.OleDb.OleDbType.Date, 8, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("Param2", System.Data.OleDb.OleDbType.Guid, 16)});
            ((System.ComponentModel.ISupportInitialize)(this.dsUrlaubVerlauf1)).EndInit();

        }
        #endregion

		public DBUrlaubVerlauf()
		{
			InitializeComponent();
		}

        public override void New()
        {
            //PMDS.DB.PMDSBusiness.addProtocollEntry("DBUrlaubVerlauf.Urlaub-Verlauf added", "DBUrlaubVerlauf");

            ITEM.Clear();

            dsUrlaubVerlauf.UrlaubVerlaufRow r = ITEM.NewUrlaubVerlaufRow();

            r.ID = Guid.NewGuid();
            r.IDAufenthalt = Guid.Empty;
            r.StartDatum = DateTime.Now;
            //r.EndeDatum	= DateTime.Now;
            r.Text = "";

            ITEM.AddUrlaubVerlaufRow(r);
        }

		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daUrlaubVerlaufByID;	}
		}
        		 
		public virtual dsUrlaubVerlauf.UrlaubVerlaufDataTable ITEM
		{
			get	{	return dsUrlaubVerlauf1.UrlaubVerlauf;	}
		}

		DataTable IDBBase.ITEM
		{
			get	{	return this.ITEM;	}
		}
        
		public dsUrlaubVerlauf.UrlaubVerlaufDataTable ByAufenthalt(Guid id)
		{
			dsUrlaubVerlauf ds = new dsUrlaubVerlauf();
			daUlraubVerlaufByAufenthalt.SelectCommand.Parameters[0].Value = id;
			DataBase.Fill(daUlraubVerlaufByAufenthalt, ds.UrlaubVerlauf);
			return ds.UrlaubVerlauf;
		}
        public dsUrlaubVerlauf.UrlaubVerlaufDataTable alleUrlaube(Guid idPatient, DateTime von, DateTime bis)
        {
            dsUrlaubVerlauf ds = new dsUrlaubVerlauf();
            this.daAlleUrlaube.SelectCommand.Parameters[0].Value = von;

            DateTime bis2 = new DateTime(bis.Year, bis.Month, bis.Day, 23, 59, 59);
            this.daAlleUrlaube.SelectCommand.Parameters[1].Value = bis2;
            this.daAlleUrlaube.SelectCommand.Parameters[2].Value = idPatient;

            DataBase.Fill(daAlleUrlaube, ds.UrlaubVerlauf);
            return ds.UrlaubVerlauf;
        }
	
    }
}
