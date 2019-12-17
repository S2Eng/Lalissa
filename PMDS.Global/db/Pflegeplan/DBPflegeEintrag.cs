//----------------------------------------------------------------------------
/// <summary>
///	DBPflegeEintrag.cs
/// Erstellt am:	15.11.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;

using RBU;
using PMDS.Global;
using PMDS.Data.PflegePlan;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die Pflege Einträge.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBPflegeEintrag : DBBase, IDBBase
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daPflegeEintragByID;
		private System.Data.OleDb.OleDbDataAdapter daPflegeEintragByAufenthalt;
        private PMDS.Data.PflegePlan.dsPflegeEintrag dsPflegeEintrag1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private OleDbDataAdapter daPflegeEintragbyEvaluierung;
        private OleDbCommand oleDbCommand1;
        private OleDbCommand oleDbInsertCommand1;
        private OleDbDataAdapter daPflegeEintragByAufenthaltEvaluierung;
        private OleDbCommand oleDbCommand2;
        private OleDbCommand oleDbSelectCommand3;
        private OleDbDataAdapter daEvaluierungKeineHistorie;
        private OleDbConnection oleDbConnection2;
        private OleDbCommand oleDbDeleteCommand;
        private OleDbCommand oleDbInsertCommand;
        private OleDbCommand oleDbUpdateCommand;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBPflegeEintrag()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPflegeEintrag));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daPflegeEintragByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPflegeEintragByAufenthalt = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daPflegeEintragbyEvaluierung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPflegeEintragByAufenthaltEvaluierung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection2 = new System.Data.OleDb.OleDbConnection();
            this.daEvaluierungKeineHistorie = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.dsPflegeEintrag1 = new PMDS.Data.PflegePlan.dsPflegeEintrag();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegeEintrag1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // daPflegeEintragByID
            // 
            this.daPflegeEintragByID.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPflegeEintragByID.InsertCommand = this.oleDbInsertCommand1;
            this.daPflegeEintragByID.SelectCommand = this.oleDbSelectCommand1;
            this.daPflegeEintragByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IstDauer", "IstDauer"),
                        new System.Data.Common.DataColumnMapping("DurchgefuehrtJN", "DurchgefuehrtJN"),
                        new System.Data.Common.DataColumnMapping("EintragsTyp", "EintragsTyp"),
                        new System.Data.Common.DataColumnMapping("Wichtig", "Wichtig"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("IDWichtig", "IDWichtig"),
                        new System.Data.Common.DataColumnMapping("IDEvaluierung", "IDEvaluierung"),
                        new System.Data.Common.DataColumnMapping("EvalStatus", "EvalStatus"),
                        new System.Data.Common.DataColumnMapping("PflegeplanText", "PflegeplanText"),
                        new System.Data.Common.DataColumnMapping("IDSollberufsstand", "IDSollberufsstand"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlanBerufsstand", "IDPflegePlanBerufsstand"),
                        new System.Data.Common.DataColumnMapping("Solldauer", "Solldauer"),
                        new System.Data.Common.DataColumnMapping("IDPflegeplanH", "IDPflegeplanH"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("PflegePlanDauer", "PflegePlanDauer"),
                        new System.Data.Common.DataColumnMapping("IDDekurs", "IDDekurs"),
                        new System.Data.Common.DataColumnMapping("CC", "CC"),
                        new System.Data.Common.DataColumnMapping("IDExtern", "IDExtern"),
                        new System.Data.Common.DataColumnMapping("Startdatum_Neu", "Startdatum_Neu"),
                        new System.Data.Common.DataColumnMapping("TextRtf", "TextRtf"),
                        new System.Data.Common.DataColumnMapping("Dekursherkunft", "Dekursherkunft"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetJN", "AbgezeichnetJN"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetIDBenutzer", "AbgezeichnetIDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetAm", "AbgezeichnetAm"),
                        new System.Data.Common.DataColumnMapping("AbzeichnenJN", "AbzeichnenJN"),
                        new System.Data.Common.DataColumnMapping("HAGPflichtigJN", "HAGPflichtigJN"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("LogInNameFrei", "LogInNameFrei")})});
            this.daPflegeEintragByID.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [PflegeEintrag] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitpunkt"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("IstDauer", System.Data.OleDb.OleDbType.Integer, 0, "IstDauer"),
            new System.Data.OleDb.OleDbParameter("DurchgefuehrtJN", System.Data.OleDb.OleDbType.Boolean, 0, "DurchgefuehrtJN"),
            new System.Data.OleDb.OleDbParameter("EintragsTyp", System.Data.OleDb.OleDbType.Integer, 0, "EintragsTyp"),
            new System.Data.OleDb.OleDbParameter("Wichtig", System.Data.OleDb.OleDbType.Integer, 0, "Wichtig"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"),
            new System.Data.OleDb.OleDbParameter("IDWichtig", System.Data.OleDb.OleDbType.Guid, 0, "IDWichtig"),
            new System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 0, "IDEvaluierung"),
            new System.Data.OleDb.OleDbParameter("EvalStatus", System.Data.OleDb.OleDbType.Integer, 0, "EvalStatus"),
            new System.Data.OleDb.OleDbParameter("PflegeplanText", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeplanText"),
            new System.Data.OleDb.OleDbParameter("IDSollberufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDSollberufsstand"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlanBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlanBerufsstand"),
            new System.Data.OleDb.OleDbParameter("Solldauer", System.Data.OleDb.OleDbType.Integer, 0, "Solldauer"),
            new System.Data.OleDb.OleDbParameter("IDPflegeplanH", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegeplanH"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("PflegePlanDauer", System.Data.OleDb.OleDbType.Integer, 0, "PflegePlanDauer"),
            new System.Data.OleDb.OleDbParameter("IDDekurs", System.Data.OleDb.OleDbType.Guid, 0, "IDDekurs"),
            new System.Data.OleDb.OleDbParameter("CC", System.Data.OleDb.OleDbType.Boolean, 0, "CC"),
            new System.Data.OleDb.OleDbParameter("IDExtern", System.Data.OleDb.OleDbType.Guid, 0, "IDExtern"),
            new System.Data.OleDb.OleDbParameter("Startdatum_Neu", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Startdatum_Neu"),
            new System.Data.OleDb.OleDbParameter("TextRtf", System.Data.OleDb.OleDbType.LongVarChar, 0, "TextRtf"),
            new System.Data.OleDb.OleDbParameter("Dekursherkunft", System.Data.OleDb.OleDbType.Integer, 0, "Dekursherkunft"),
            new System.Data.OleDb.OleDbParameter("AbgezeichnetJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbgezeichnetJN"),
            new System.Data.OleDb.OleDbParameter("AbgezeichnetIDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "AbgezeichnetIDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgezeichnetAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AbgezeichnetAm"),
            new System.Data.OleDb.OleDbParameter("AbzeichnenJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbzeichnenJN"),
            new System.Data.OleDb.OleDbParameter("HAGPflichtigJN", System.Data.OleDb.OleDbType.Boolean, 0, "HAGPflichtigJN"),
            new System.Data.OleDb.OleDbParameter("IDBefund", System.Data.OleDb.OleDbType.Guid, 0, "IDBefund"),
            new System.Data.OleDb.OleDbParameter("LogInNameFrei", System.Data.OleDb.OleDbType.VarWChar, 0, "LogInNameFrei")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitpunkt"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("IstDauer", System.Data.OleDb.OleDbType.Integer, 0, "IstDauer"),
            new System.Data.OleDb.OleDbParameter("DurchgefuehrtJN", System.Data.OleDb.OleDbType.Boolean, 0, "DurchgefuehrtJN"),
            new System.Data.OleDb.OleDbParameter("EintragsTyp", System.Data.OleDb.OleDbType.Integer, 0, "EintragsTyp"),
            new System.Data.OleDb.OleDbParameter("Wichtig", System.Data.OleDb.OleDbType.Integer, 0, "Wichtig"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"),
            new System.Data.OleDb.OleDbParameter("IDWichtig", System.Data.OleDb.OleDbType.Guid, 0, "IDWichtig"),
            new System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 0, "IDEvaluierung"),
            new System.Data.OleDb.OleDbParameter("EvalStatus", System.Data.OleDb.OleDbType.Integer, 0, "EvalStatus"),
            new System.Data.OleDb.OleDbParameter("PflegeplanText", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeplanText"),
            new System.Data.OleDb.OleDbParameter("IDSollberufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDSollberufsstand"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlanBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlanBerufsstand"),
            new System.Data.OleDb.OleDbParameter("Solldauer", System.Data.OleDb.OleDbType.Integer, 0, "Solldauer"),
            new System.Data.OleDb.OleDbParameter("IDPflegeplanH", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegeplanH"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("PflegePlanDauer", System.Data.OleDb.OleDbType.Integer, 0, "PflegePlanDauer"),
            new System.Data.OleDb.OleDbParameter("IDDekurs", System.Data.OleDb.OleDbType.Guid, 0, "IDDekurs"),
            new System.Data.OleDb.OleDbParameter("CC", System.Data.OleDb.OleDbType.Boolean, 0, "CC"),
            new System.Data.OleDb.OleDbParameter("IDExtern", System.Data.OleDb.OleDbType.Guid, 0, "IDExtern"),
            new System.Data.OleDb.OleDbParameter("Startdatum_Neu", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Startdatum_Neu"),
            new System.Data.OleDb.OleDbParameter("TextRtf", System.Data.OleDb.OleDbType.LongVarChar, 0, "TextRtf"),
            new System.Data.OleDb.OleDbParameter("Dekursherkunft", System.Data.OleDb.OleDbType.Integer, 0, "Dekursherkunft"),
            new System.Data.OleDb.OleDbParameter("AbgezeichnetJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbgezeichnetJN"),
            new System.Data.OleDb.OleDbParameter("AbgezeichnetIDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "AbgezeichnetIDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgezeichnetAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AbgezeichnetAm"),
            new System.Data.OleDb.OleDbParameter("AbzeichnenJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbzeichnenJN"),
            new System.Data.OleDb.OleDbParameter("HAGPflichtigJN", System.Data.OleDb.OleDbType.Boolean, 0, "HAGPflichtigJN"),
            new System.Data.OleDb.OleDbParameter("IDBefund", System.Data.OleDb.OleDbType.Guid, 0, "IDBefund"),
            new System.Data.OleDb.OleDbParameter("LogInNameFrei", System.Data.OleDb.OleDbType.VarWChar, 0, "LogInNameFrei"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPflegeEintragByAufenthalt
            // 
            this.daPflegeEintragByAufenthalt.DeleteCommand = this.oleDbDeleteCommand;
            this.daPflegeEintragByAufenthalt.InsertCommand = this.oleDbInsertCommand;
            this.daPflegeEintragByAufenthalt.SelectCommand = this.oleDbSelectCommand2;
            this.daPflegeEintragByAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IstDauer", "IstDauer"),
                        new System.Data.Common.DataColumnMapping("DurchgefuehrtJN", "DurchgefuehrtJN"),
                        new System.Data.Common.DataColumnMapping("EintragsTyp", "EintragsTyp"),
                        new System.Data.Common.DataColumnMapping("Wichtig", "Wichtig"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("IDWichtig", "IDWichtig"),
                        new System.Data.Common.DataColumnMapping("IDEvaluierung", "IDEvaluierung"),
                        new System.Data.Common.DataColumnMapping("EvalStatus", "EvalStatus"),
                        new System.Data.Common.DataColumnMapping("PflegeplanText", "PflegeplanText"),
                        new System.Data.Common.DataColumnMapping("IDSollberufsstand", "IDSollberufsstand"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlanBerufsstand", "IDPflegePlanBerufsstand"),
                        new System.Data.Common.DataColumnMapping("Solldauer", "Solldauer"),
                        new System.Data.Common.DataColumnMapping("IDPflegeplanH", "IDPflegeplanH"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("PflegePlanDauer", "PflegePlanDauer"),
                        new System.Data.Common.DataColumnMapping("IDDekurs", "IDDekurs"),
                        new System.Data.Common.DataColumnMapping("CC", "CC"),
                        new System.Data.Common.DataColumnMapping("IDExtern", "IDExtern"),
                        new System.Data.Common.DataColumnMapping("Startdatum_Neu", "Startdatum_Neu"),
                        new System.Data.Common.DataColumnMapping("TextRtf", "TextRtf"),
                        new System.Data.Common.DataColumnMapping("Dekursherkunft", "Dekursherkunft"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetJN", "AbgezeichnetJN"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetIDBenutzer", "AbgezeichnetIDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetAm", "AbgezeichnetAm"),
                        new System.Data.Common.DataColumnMapping("AbzeichnenJN", "AbzeichnenJN"),
                        new System.Data.Common.DataColumnMapping("HAGPflichtigJN", "HAGPflichtigJN"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("LogInNameFrei", "LogInNameFrei")})});
            this.daPflegeEintragByAufenthalt.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});
            // 
            // daPflegeEintragbyEvaluierung
            // 
            this.daPflegeEintragbyEvaluierung.SelectCommand = this.oleDbCommand1;
            this.daPflegeEintragbyEvaluierung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IstDauer", "IstDauer"),
                        new System.Data.Common.DataColumnMapping("DurchgefuehrtJN", "DurchgefuehrtJN"),
                        new System.Data.Common.DataColumnMapping("EintragsTyp", "EintragsTyp"),
                        new System.Data.Common.DataColumnMapping("Wichtig", "Wichtig"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("IDWichtig", "IDWichtig"),
                        new System.Data.Common.DataColumnMapping("IDEvaluierung", "IDEvaluierung"),
                        new System.Data.Common.DataColumnMapping("EvalStatus", "EvalStatus"),
                        new System.Data.Common.DataColumnMapping("PflegeplanText", "PflegeplanText"),
                        new System.Data.Common.DataColumnMapping("IDSollberufsstand", "IDSollberufsstand"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlanBerufsstand", "IDPflegePlanBerufsstand"),
                        new System.Data.Common.DataColumnMapping("Solldauer", "Solldauer"),
                        new System.Data.Common.DataColumnMapping("IDPflegeplanH", "IDPflegeplanH"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("PflegePlanDauer", "PflegePlanDauer"),
                        new System.Data.Common.DataColumnMapping("IDDekurs", "IDDekurs"),
                        new System.Data.Common.DataColumnMapping("CC", "CC"),
                        new System.Data.Common.DataColumnMapping("IDExtern", "IDExtern"),
                        new System.Data.Common.DataColumnMapping("Startdatum_Neu", "Startdatum_Neu"),
                        new System.Data.Common.DataColumnMapping("TextRtf", "TextRtf"),
                        new System.Data.Common.DataColumnMapping("Dekursherkunft", "Dekursherkunft"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetJN", "AbgezeichnetJN"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetIDBenutzer", "AbgezeichnetIDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetAm", "AbgezeichnetAm"),
                        new System.Data.Common.DataColumnMapping("AbzeichnenJN", "AbzeichnenJN"),
                        new System.Data.Common.DataColumnMapping("HAGPflichtigJN", "HAGPflichtigJN"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("LogInNameFrei", "LogInNameFrei")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 16, "IDEvaluierung")});
            // 
            // daPflegeEintragByAufenthaltEvaluierung
            // 
            this.daPflegeEintragByAufenthaltEvaluierung.SelectCommand = this.oleDbCommand2;
            this.daPflegeEintragByAufenthaltEvaluierung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IstDauer", "IstDauer"),
                        new System.Data.Common.DataColumnMapping("DurchgefuehrtJN", "DurchgefuehrtJN"),
                        new System.Data.Common.DataColumnMapping("EintragsTyp", "EintragsTyp"),
                        new System.Data.Common.DataColumnMapping("Wichtig", "Wichtig"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("IDWichtig", "IDWichtig"),
                        new System.Data.Common.DataColumnMapping("IDEvaluierung", "IDEvaluierung"),
                        new System.Data.Common.DataColumnMapping("EvalStatus", "EvalStatus"),
                        new System.Data.Common.DataColumnMapping("PflegeplanText", "PflegeplanText"),
                        new System.Data.Common.DataColumnMapping("IDSollberufsstand", "IDSollberufsstand"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlanBerufsstand", "IDPflegePlanBerufsstand"),
                        new System.Data.Common.DataColumnMapping("Solldauer", "Solldauer"),
                        new System.Data.Common.DataColumnMapping("IDPflegeplanH", "IDPflegeplanH"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("PflegePlanDauer", "PflegePlanDauer"),
                        new System.Data.Common.DataColumnMapping("IDDekurs", "IDDekurs"),
                        new System.Data.Common.DataColumnMapping("CC", "CC"),
                        new System.Data.Common.DataColumnMapping("IDExtern", "IDExtern"),
                        new System.Data.Common.DataColumnMapping("Startdatum_Neu", "Startdatum_Neu"),
                        new System.Data.Common.DataColumnMapping("TextRtf", "TextRtf"),
                        new System.Data.Common.DataColumnMapping("Dekursherkunft", "Dekursherkunft"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetJN", "AbgezeichnetJN"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetIDBenutzer", "AbgezeichnetIDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetAm", "AbgezeichnetAm"),
                        new System.Data.Common.DataColumnMapping("AbzeichnenJN", "AbzeichnenJN"),
                        new System.Data.Common.DataColumnMapping("HAGPflichtigJN", "HAGPflichtigJN"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("LogInNameFrei", "LogInNameFrei")})});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 16, "IDPflegePlan")});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = this.oleDbConnection2;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("EintragsTyp", System.Data.OleDb.OleDbType.Integer, 4, "EintragsTyp")});
            // 
            // oleDbConnection2
            // 
            this.oleDbConnection2.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // daEvaluierungKeineHistorie
            // 
            this.daEvaluierungKeineHistorie.SelectCommand = this.oleDbSelectCommand3;
            this.daEvaluierungKeineHistorie.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("EintragsTyp", "EintragsTyp")})});
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = resources.GetString("oleDbInsertCommand.CommandText");
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitpunkt"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("IstDauer", System.Data.OleDb.OleDbType.Integer, 0, "IstDauer"),
            new System.Data.OleDb.OleDbParameter("DurchgefuehrtJN", System.Data.OleDb.OleDbType.Boolean, 0, "DurchgefuehrtJN"),
            new System.Data.OleDb.OleDbParameter("EintragsTyp", System.Data.OleDb.OleDbType.Integer, 0, "EintragsTyp"),
            new System.Data.OleDb.OleDbParameter("Wichtig", System.Data.OleDb.OleDbType.Integer, 0, "Wichtig"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"),
            new System.Data.OleDb.OleDbParameter("IDWichtig", System.Data.OleDb.OleDbType.Guid, 0, "IDWichtig"),
            new System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 0, "IDEvaluierung"),
            new System.Data.OleDb.OleDbParameter("EvalStatus", System.Data.OleDb.OleDbType.Integer, 0, "EvalStatus"),
            new System.Data.OleDb.OleDbParameter("PflegeplanText", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeplanText"),
            new System.Data.OleDb.OleDbParameter("IDSollberufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDSollberufsstand"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlanBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlanBerufsstand"),
            new System.Data.OleDb.OleDbParameter("Solldauer", System.Data.OleDb.OleDbType.Integer, 0, "Solldauer"),
            new System.Data.OleDb.OleDbParameter("IDPflegeplanH", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegeplanH"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("PflegePlanDauer", System.Data.OleDb.OleDbType.Integer, 0, "PflegePlanDauer"),
            new System.Data.OleDb.OleDbParameter("IDDekurs", System.Data.OleDb.OleDbType.Guid, 0, "IDDekurs"),
            new System.Data.OleDb.OleDbParameter("CC", System.Data.OleDb.OleDbType.Boolean, 0, "CC"),
            new System.Data.OleDb.OleDbParameter("IDExtern", System.Data.OleDb.OleDbType.Guid, 0, "IDExtern"),
            new System.Data.OleDb.OleDbParameter("Startdatum_Neu", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Startdatum_Neu"),
            new System.Data.OleDb.OleDbParameter("TextRtf", System.Data.OleDb.OleDbType.LongVarChar, 0, "TextRtf"),
            new System.Data.OleDb.OleDbParameter("Dekursherkunft", System.Data.OleDb.OleDbType.Integer, 0, "Dekursherkunft"),
            new System.Data.OleDb.OleDbParameter("AbgezeichnetJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbgezeichnetJN"),
            new System.Data.OleDb.OleDbParameter("AbgezeichnetIDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "AbgezeichnetIDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgezeichnetAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AbgezeichnetAm"),
            new System.Data.OleDb.OleDbParameter("AbzeichnenJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbzeichnenJN"),
            new System.Data.OleDb.OleDbParameter("HAGPflichtigJN", System.Data.OleDb.OleDbType.Boolean, 0, "HAGPflichtigJN"),
            new System.Data.OleDb.OleDbParameter("IDBefund", System.Data.OleDb.OleDbType.Guid, 0, "IDBefund"),
            new System.Data.OleDb.OleDbParameter("LogInNameFrei", System.Data.OleDb.OleDbType.VarWChar, 0, "LogInNameFrei")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitpunkt"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("IstDauer", System.Data.OleDb.OleDbType.Integer, 0, "IstDauer"),
            new System.Data.OleDb.OleDbParameter("DurchgefuehrtJN", System.Data.OleDb.OleDbType.Boolean, 0, "DurchgefuehrtJN"),
            new System.Data.OleDb.OleDbParameter("EintragsTyp", System.Data.OleDb.OleDbType.Integer, 0, "EintragsTyp"),
            new System.Data.OleDb.OleDbParameter("Wichtig", System.Data.OleDb.OleDbType.Integer, 0, "Wichtig"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"),
            new System.Data.OleDb.OleDbParameter("IDWichtig", System.Data.OleDb.OleDbType.Guid, 0, "IDWichtig"),
            new System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 0, "IDEvaluierung"),
            new System.Data.OleDb.OleDbParameter("EvalStatus", System.Data.OleDb.OleDbType.Integer, 0, "EvalStatus"),
            new System.Data.OleDb.OleDbParameter("PflegeplanText", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeplanText"),
            new System.Data.OleDb.OleDbParameter("IDSollberufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDSollberufsstand"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlanBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlanBerufsstand"),
            new System.Data.OleDb.OleDbParameter("Solldauer", System.Data.OleDb.OleDbType.Integer, 0, "Solldauer"),
            new System.Data.OleDb.OleDbParameter("IDPflegeplanH", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegeplanH"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("PflegePlanDauer", System.Data.OleDb.OleDbType.Integer, 0, "PflegePlanDauer"),
            new System.Data.OleDb.OleDbParameter("IDDekurs", System.Data.OleDb.OleDbType.Guid, 0, "IDDekurs"),
            new System.Data.OleDb.OleDbParameter("CC", System.Data.OleDb.OleDbType.Boolean, 0, "CC"),
            new System.Data.OleDb.OleDbParameter("IDExtern", System.Data.OleDb.OleDbType.Guid, 0, "IDExtern"),
            new System.Data.OleDb.OleDbParameter("Startdatum_Neu", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Startdatum_Neu"),
            new System.Data.OleDb.OleDbParameter("TextRtf", System.Data.OleDb.OleDbType.LongVarChar, 0, "TextRtf"),
            new System.Data.OleDb.OleDbParameter("Dekursherkunft", System.Data.OleDb.OleDbType.Integer, 0, "Dekursherkunft"),
            new System.Data.OleDb.OleDbParameter("AbgezeichnetJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbgezeichnetJN"),
            new System.Data.OleDb.OleDbParameter("AbgezeichnetIDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "AbgezeichnetIDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgezeichnetAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AbgezeichnetAm"),
            new System.Data.OleDb.OleDbParameter("AbzeichnenJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbzeichnenJN"),
            new System.Data.OleDb.OleDbParameter("HAGPflichtigJN", System.Data.OleDb.OleDbType.Boolean, 0, "HAGPflichtigJN"),
            new System.Data.OleDb.OleDbParameter("IDBefund", System.Data.OleDb.OleDbType.Guid, 0, "IDBefund"),
            new System.Data.OleDb.OleDbParameter("LogInNameFrei", System.Data.OleDb.OleDbType.VarWChar, 0, "LogInNameFrei"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [PflegeEintrag] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsPflegeEintrag1
            // 
            this.dsPflegeEintrag1.DataSetName = "dsPflegeEintrag";
            this.dsPflegeEintrag1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsPflegeEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegeEintrag1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daPflegeEintragByID;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen Eintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
			ITEM.AddPflegeEintragRow(Guid.NewGuid(), Guid.Empty, Guid.Empty, Guid.Empty,
									Guid.Empty, DateTime.Now, DateTime.Now, "", 0, true,
									0, 0, Guid.Empty, Guid.Empty, Guid.Empty, -1, "", Guid.Empty, Guid.Empty,
                                    0, Guid.Empty, Guid.Empty, Guid.Empty, 0, Guid.Empty, false, Guid.Empty, new DateTime(1900, 1, 1), "", -1,
                                    false, Guid.Empty, new DateTime(1900, 1, 1), false, false, Guid.Empty, "");

			ITEM[0].SetIDPflegePlanNull();
			ITEM[0].SetIDEintragNull();
			ITEM[0].SetIDWichtigNull();
            ITEM[0].SetIDEvaluierungNull();
            ITEM[0].SetIDSollberufsstandNull();
            ITEM[0].SetIDPflegePlanBerufsstandNull();
            ITEM[0].SetIDPflegeplanHNull();
            ITEM[0].SetIDBereichNull();
            ITEM[0].SetIDAbteilungNull();
            ITEM[0].SetIDExternNull();
            ITEM[0].SetIDExternNull();
            ITEM[0].SetAbgezeichnetAmNull();
            ITEM[0].SetStartdatum_NeuNull();
            ITEM[0].SetIDBefundNull();
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Gemäß Anforderung wird zum Pflegeeintrag der ursprüngliche M Text, 
        /// der SollBerufstand und der PflegePlanBerufstand mitgespeichert werden
        /// Dies wird für einfachere Auswertungen benötigt
        /// </summary>
        //----------------------------------------------------------------------------
        public override void Write()
        {
            if (!ITEM[0].IsIDPflegePlanNull())
            {
                DBPflegePlan db = new DBPflegePlan();
                db.ReadOnce(ITEM[0].IDPflegePlan);

                dsPflegePlan.PflegePlanRow r = db.PFLEGEPLAN_EINTRAEGE[0];

                if (r.EintragGruppe.ToUpper() == "M")
                {
                    ITEM[0].PflegeplanText = r.Text;
                }
                else if (r.EintragGruppe.ToUpper() == "T")
                {
                    ITEM[0].PflegeplanText = "Termin: " + r.Text;
                    ITEM[0].EintragsTyp = (int) PflegeEintragTyp.TERMIN;
                }        
                
                if (r.IDBerufsstand == Guid.Empty)
                {
                    ITEM[0].SetIDPflegePlanBerufsstandNull();
                    ITEM[0].SetIDSollberufsstandNull();
                }

                else
                {
                    ITEM[0].IDPflegePlanBerufsstand = r.IDBerufsstand;
                    ITEM[0].IDSollberufsstand = r.IDBerufsstand;            //Keine Unterscheidung zwischen Sollberufsstand aus Eintrag_Zusatz und geplantem Berufsstand
                }

                //20.04.2007 MDA
                ITEM[0].PflegePlanDauer = r.IsDauerNull() ? 0 : r.Dauer;
                ITEM[0].Solldauer = r.IsDauerNull() ? 0 : r.Dauer;         //Keine Unterscheidung mehr zwischen uwischen Soll und Plan 
                
            }
            else if (ITEM[0].EintragsTyp == (int) PflegeEintragTyp.UNEXP_MASSNAHME && ENV.BERUFID != null)
            {
                ITEM[0].IDPflegePlanBerufsstand = ENV.BERUFID;
                ITEM[0].IDSollberufsstand = ENV.BERUFID;
            }



            PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
            PMDS.db.Entities.Aufenthalt rAufenthalt = PMDSBusiness1.getAufenthalt(ITEM[0].IDAufenthalt);

//            Guid IDSollberufsstand = ITEM[0].IsIDEintragNull() ? Guid.Empty : DBUtil.GetMassnahmeSollBerufsstand(ITEM[0].IDEintrag, ENV.CurrentIDAbteilung);
//            if (IDSollberufsstand != Guid.Empty)
//                ITEM[0].IDSollberufsstand = IDSollberufsstand;

//            //19.04.2007 MDA: Solldauer, IDPflegeplanH, IDBereich und IDAbteilung übernehmen
//            ITEM[0].Solldauer = ITEM[0].IsIDEintragNull() ? 0 : DBUtil.GetMassnahmeSolldauer(ITEM[0].IDEintrag, ENV.CurrentIDAbteilung);    //Solldauer

            //Keine Referenz zu PflegeplanH erforderlich
            //Guid IDPflegePlanH = ITEM[0].IsIDPflegePlanNull() ? Guid.Empty : DBUtil.GetMassnahmePflegeplanH(ITEM[0].IDPflegePlan);          //IDPflegePlanH
            //if (IDPflegePlanH != Guid.Empty)
            //    ITEM[0].IDPflegeplanH = IDPflegePlanH;

            Guid IDBereich = ITEM[0].IsIDAufenthaltNull() ? Guid.Empty : (Guid) rAufenthalt.IDBereich; //DBUtil.GetMassnahmeBereich(ITEM[0].IDAufenthalt);                  //IDBereich
            if (IDBereich != Guid.Empty)
                ITEM[0].IDBereich = IDBereich;

            Guid IDAbteilung = ITEM[0].IsIDAufenthaltNull() ? Guid.Empty : (Guid) rAufenthalt.IDAbteilung;   //DBUtil.GetMassnahmeAbteilung(ITEM[0].IDAufenthalt);              //IDAbteilung
            if(IDAbteilung != Guid.Empty)
                ITEM[0].IDAbteilung = IDAbteilung;

            base.Write();
        }

        
		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsPflegeEintrag.PflegeEintragDataTable ITEM
		{
			get	{	return dsPflegeEintrag1.PflegeEintrag;	}
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
		/// PflegeEinträge für Aufenthalt ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public dsPflegeEintrag.PflegeEintragDataTable ByAufenthalt(Guid id)
		{
			dsPflegeEintrag ds = new dsPflegeEintrag();
			daPflegeEintragByAufenthalt.SelectCommand.Parameters[0].Value = id;
			DataBase.Fill(daPflegeEintragByAufenthalt, ds.PflegeEintrag);
			return ds.PflegeEintrag;
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// PflegeEinträge für Aufenthalt ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        //public dsPflegeEintrag ByAufenthaltEvaluierung(Guid IDAufenthalt, Guid IDEintrag)
        //{
        //    dsPflegeEintrag ds = new dsPflegeEintrag();
        //    daPflegeEintragByAufenthaltEvaluierung.SelectCommand.Parameters[0].Value = IDAufenthalt;
        //    daPflegeEintragByAufenthaltEvaluierung.SelectCommand.Parameters[1].Value = IDEintrag;
        //    DataBase.Fill(daPflegeEintragByAufenthaltEvaluierung, ds.PflegeEintrag);
        //    return ds;
        //}
        //Gernot%%
        public dsPflegeEintrag ByAufenthaltEvaluierung(Guid IDAufenthalt, Guid IDPflegeplan)
        {
            dsPflegeEintrag ds = new dsPflegeEintrag();
            daPflegeEintragByAufenthaltEvaluierung.SelectCommand.Parameters[0].Value = IDAufenthalt;
            daPflegeEintragByAufenthaltEvaluierung.SelectCommand.Parameters[1].Value = IDPflegeplan;
            DataBase.Fill(daPflegeEintragByAufenthaltEvaluierung, ds.PflegeEintrag);
            return ds;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Evaluierungs PflegeEinträge für Aufenthalt ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        public dsPflegeEintrag.PflegeEintragDataTable ByEvaluierung(Guid IDEvaluierung)
        {
            dsPflegeEintrag.PflegeEintragDataTable dt = new dsPflegeEintrag.PflegeEintragDataTable();
            daPflegeEintragbyEvaluierung.SelectCommand.Parameters[0].Value = IDEvaluierung;
            DataBase.Fill(daPflegeEintragbyEvaluierung, dt);
            return dt;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert zu einem bestimmten Aufenthalt und eintrag ein letztes Durchführungsdatum
        /// oder null wenn kein Eintrag gefunden wurde
        /// </summary>
        //----------------------------------------------------------------------------
        public static dsPflegeEintrag.PflegeEintragRow GetLastByAufenthalt(Guid IDAufenthalt, Guid IDEintrag)
        {
            string sSelect = "select Top 1 * from PflegeEintrag where IDAufenthalt =? and IDEintrag = ? order by Zeitpunkt desc";
            OleDbCommand cmd = new OleDbCommand(sSelect);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            dsPflegeEintrag.PflegeEintragDataTable dt = new dsPflegeEintrag.PflegeEintragDataTable();
            da.SelectCommand.Parameters.AddWithValue("IDA", IDAufenthalt);
            da.SelectCommand.Parameters.AddWithValue("IDE", IDEintrag);
            DataBase.Fill(da, dt);
            if (dt.Count == 0)
                return null;

            return dt[0];
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert true wenn zu dem Pflegeplan ein heutiger Eintrag existiert
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool IsToDaySigned(Guid IDPflegePlan)
        {
            try
            {
                string sSql = "select ID from Pflegeeintrag where IDPflegePlan = ? and  Zeitpunkt > ? and Zeitpunkt < ?";
                OleDbCommand cmd = new OleDbCommand(sSql);
                cmd.Parameters.AddWithValue("IDPflegePlan", IDPflegePlan);
                cmd.Parameters.AddWithValue("t1", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("t2", DateTime.Now.Date.AddDays(1));
                bool bRet = false;
                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    System.Data.DataRow r = dtSelect.Rows[0];
                    return true;
                }

                return bRet;

            }
            catch (Exception ex)
            {
                throw new Exception("ExistPDxEintrag: " + ex.ToString());
            }
        }
	}
}
