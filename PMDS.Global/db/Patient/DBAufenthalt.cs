//----------------------------------------------------------------------------
/// <summary>
///	DBAufenthalt.cs
/// Erstellt am:	12.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;

using PMDS.Global;
using PMDS.Data.Patient;
using RBU;


namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die Aufenthalte.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBAufenthalt : DBBase, IDBBase
    {
		private System.Data.OleDb.OleDbDataAdapter daAufenthaltByPatient;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbDataAdapter daHistoryByPatient;
        private OleDbCommand oleDbSelectCommand3;
        private OleDbConnection oleDbConnection1;
        private OleDbCommand oleDbInsertCommand2;
        private OleDbCommand oleDbUpdateCommand2;
        private OleDbCommand oleDbDeleteCommand2;
        private OleDbDataAdapter daAufenthaltByID;
        private OleDbCommand oleDbDeleteCommand;
        private OleDbCommand oleDbInsertCommand;
        private OleDbCommand oleDbUpdateCommand;
        private dsAufenthalt dsAufenthalt1;
        private OleDbDataAdapter daAktuellAufenthaltByPatient;
        private OleDbCommand oleDbCommand2;
        private OleDbCommand oleDbCommand4;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBAufenthalt()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBAufenthalt));
            this.daAufenthaltByPatient = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.daHistoryByPatient = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daAufenthaltByID = new System.Data.OleDb.OleDbDataAdapter();
            this.dsAufenthalt1 = new PMDS.Data.Patient.dsAufenthalt();
            this.daAktuellAufenthaltByPatient = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsAufenthalt1)).BeginInit();
            // 
            // daAufenthaltByPatient
            // 
            this.daAufenthaltByPatient.DeleteCommand = this.oleDbDeleteCommand;
            this.daAufenthaltByPatient.InsertCommand = this.oleDbInsertCommand;
            this.daAufenthaltByPatient.SelectCommand = this.oleDbSelectCommand1;
            this.daAufenthaltByPatient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Aufenthalt", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDAufenthaltVerlauf", "IDAufenthaltVerlauf"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Aufnahme", "IDBenutzer_Aufnahme"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Entlassung", "IDBenutzer_Entlassung"),
                        new System.Data.Common.DataColumnMapping("IDEinrichtung_Aufnahme", "IDEinrichtung_Aufnahme"),
                        new System.Data.Common.DataColumnMapping("IDEinrichtung_Entlassung", "IDEinrichtung_Entlassung"),
                        new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Entlassungszeitpunkt", "Entlassungszeitpunkt"),
                        new System.Data.Common.DataColumnMapping("AufnahmeArt", "AufnahmeArt"),
                        new System.Data.Common.DataColumnMapping("BegleitungVon", "BegleitungVon"),
                        new System.Data.Common.DataColumnMapping("Entlassungsbemerkung", "Entlassungsbemerkung"),
                        new System.Data.Common.DataColumnMapping("SomatischeAuff", "SomatischeAuff"),
                        new System.Data.Common.DataColumnMapping("PsychischeAuff", "PsychischeAuff"),
                        new System.Data.Common.DataColumnMapping("VerhaltenAufnahme", "VerhaltenAufnahme"),
                        new System.Data.Common.DataColumnMapping("SonstigeBesonderheiten", "SonstigeBesonderheiten"),
                        new System.Data.Common.DataColumnMapping("SofortMassnahmen", "SofortMassnahmen"),
                        new System.Data.Common.DataColumnMapping("IDUrlaub", "IDUrlaub"),
                        new System.Data.Common.DataColumnMapping("BarcodeID", "BarcodeID"),
                        new System.Data.Common.DataColumnMapping("Fallnummer", "Fallnummer"),
                        new System.Data.Common.DataColumnMapping("Gruppenkennzahl", "Gruppenkennzahl"),
                        new System.Data.Common.DataColumnMapping("Verfuegungsdatum", "Verfuegungsdatum"),
                        new System.Data.Common.DataColumnMapping("Bermerkung", "Bermerkung"),
                        new System.Data.Common.DataColumnMapping("Besuchsregelung", "Besuchsregelung"),
                        new System.Data.Common.DataColumnMapping("Postregelung", "Postregelung"),
                        new System.Data.Common.DataColumnMapping("SonstigeRegelung", "SonstigeRegelung"),
                        new System.Data.Common.DataColumnMapping("Erwartungen", "Erwartungen"),
                        new System.Data.Common.DataColumnMapping("IDErstkontakt", "IDErstkontakt"),
                        new System.Data.Common.DataColumnMapping("Gewicht", "Gewicht"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"),
                        new System.Data.Common.DataColumnMapping("TaschengeldSollstand", "TaschengeldSollstand"),
                        new System.Data.Common.DataColumnMapping("TaschegeldVortragDatum", "TaschegeldVortragDatum"),
                        new System.Data.Common.DataColumnMapping("TaschengeldVortragBetrag", "TaschengeldVortragBetrag"),
                        new System.Data.Common.DataColumnMapping("Ausgleichszahlung", "Ausgleichszahlung"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich")})});
            this.daAufenthaltByPatient.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [Aufenthalt] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=stysrv10v;Integrated Security=SSPI;Initial Catalog" +
    "=PMDSDev";
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = resources.GetString("oleDbInsertCommand.CommandText");
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("IDAufenthaltVerlauf", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthaltVerlauf"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Aufnahme", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Aufnahme"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Entlassung", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Entlassung"),
            new System.Data.OleDb.OleDbParameter("IDEinrichtung_Aufnahme", System.Data.OleDb.OleDbType.Guid, 0, "IDEinrichtung_Aufnahme"),
            new System.Data.OleDb.OleDbParameter("IDEinrichtung_Entlassung", System.Data.OleDb.OleDbType.Guid, 0, "IDEinrichtung_Entlassung"),
            new System.Data.OleDb.OleDbParameter("Aufnahmezeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "Aufnahmezeitpunkt"),
            new System.Data.OleDb.OleDbParameter("Entlassungszeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "Entlassungszeitpunkt"),
            new System.Data.OleDb.OleDbParameter("AufnahmeArt", System.Data.OleDb.OleDbType.Integer, 0, "AufnahmeArt"),
            new System.Data.OleDb.OleDbParameter("BegleitungVon", System.Data.OleDb.OleDbType.VarChar, 0, "BegleitungVon"),
            new System.Data.OleDb.OleDbParameter("Entlassungsbemerkung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Entlassungsbemerkung"),
            new System.Data.OleDb.OleDbParameter("SomatischeAuff", System.Data.OleDb.OleDbType.VarChar, 0, "SomatischeAuff"),
            new System.Data.OleDb.OleDbParameter("PsychischeAuff", System.Data.OleDb.OleDbType.VarChar, 0, "PsychischeAuff"),
            new System.Data.OleDb.OleDbParameter("VerhaltenAufnahme", System.Data.OleDb.OleDbType.VarChar, 0, "VerhaltenAufnahme"),
            new System.Data.OleDb.OleDbParameter("SonstigeBesonderheiten", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeBesonderheiten"),
            new System.Data.OleDb.OleDbParameter("SofortMassnahmen", System.Data.OleDb.OleDbType.VarChar, 0, "SofortMassnahmen"),
            new System.Data.OleDb.OleDbParameter("IDUrlaub", System.Data.OleDb.OleDbType.Guid, 0, "IDUrlaub"),
            new System.Data.OleDb.OleDbParameter("Fallnummer", System.Data.OleDb.OleDbType.Double, 0, "Fallnummer"),
            new System.Data.OleDb.OleDbParameter("Gruppenkennzahl", System.Data.OleDb.OleDbType.VarChar, 0, "Gruppenkennzahl"),
            new System.Data.OleDb.OleDbParameter("Verfuegungsdatum", System.Data.OleDb.OleDbType.Date, 16, "Verfuegungsdatum"),
            new System.Data.OleDb.OleDbParameter("Bermerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bermerkung"),
            new System.Data.OleDb.OleDbParameter("Besuchsregelung", System.Data.OleDb.OleDbType.VarChar, 0, "Besuchsregelung"),
            new System.Data.OleDb.OleDbParameter("Postregelung", System.Data.OleDb.OleDbType.VarChar, 0, "Postregelung"),
            new System.Data.OleDb.OleDbParameter("SonstigeRegelung", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeRegelung"),
            new System.Data.OleDb.OleDbParameter("Erwartungen", System.Data.OleDb.OleDbType.VarChar, 0, "Erwartungen"),
            new System.Data.OleDb.OleDbParameter("IDErstkontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDErstkontakt"),
            new System.Data.OleDb.OleDbParameter("Gewicht", System.Data.OleDb.OleDbType.Double, 0, "Gewicht"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, "NaechsteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"),
            new System.Data.OleDb.OleDbParameter("TaschengeldSollstand", System.Data.OleDb.OleDbType.Double, 0, "TaschengeldSollstand"),
            new System.Data.OleDb.OleDbParameter("TaschegeldVortragDatum", System.Data.OleDb.OleDbType.Date, 16, "TaschegeldVortragDatum"),
            new System.Data.OleDb.OleDbParameter("TaschengeldVortragBetrag", System.Data.OleDb.OleDbType.Double, 0, "TaschengeldVortragBetrag"),
            new System.Data.OleDb.OleDbParameter("Ausgleichszahlung", System.Data.OleDb.OleDbType.Double, 0, "Ausgleichszahlung"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("IDAufenthaltVerlauf", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthaltVerlauf"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Aufnahme", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Aufnahme"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Entlassung", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Entlassung"),
            new System.Data.OleDb.OleDbParameter("IDEinrichtung_Aufnahme", System.Data.OleDb.OleDbType.Guid, 0, "IDEinrichtung_Aufnahme"),
            new System.Data.OleDb.OleDbParameter("IDEinrichtung_Entlassung", System.Data.OleDb.OleDbType.Guid, 0, "IDEinrichtung_Entlassung"),
            new System.Data.OleDb.OleDbParameter("Aufnahmezeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "Aufnahmezeitpunkt"),
            new System.Data.OleDb.OleDbParameter("Entlassungszeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "Entlassungszeitpunkt"),
            new System.Data.OleDb.OleDbParameter("AufnahmeArt", System.Data.OleDb.OleDbType.Integer, 0, "AufnahmeArt"),
            new System.Data.OleDb.OleDbParameter("BegleitungVon", System.Data.OleDb.OleDbType.VarChar, 0, "BegleitungVon"),
            new System.Data.OleDb.OleDbParameter("Entlassungsbemerkung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Entlassungsbemerkung"),
            new System.Data.OleDb.OleDbParameter("SomatischeAuff", System.Data.OleDb.OleDbType.VarChar, 0, "SomatischeAuff"),
            new System.Data.OleDb.OleDbParameter("PsychischeAuff", System.Data.OleDb.OleDbType.VarChar, 0, "PsychischeAuff"),
            new System.Data.OleDb.OleDbParameter("VerhaltenAufnahme", System.Data.OleDb.OleDbType.VarChar, 0, "VerhaltenAufnahme"),
            new System.Data.OleDb.OleDbParameter("SonstigeBesonderheiten", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeBesonderheiten"),
            new System.Data.OleDb.OleDbParameter("SofortMassnahmen", System.Data.OleDb.OleDbType.VarChar, 0, "SofortMassnahmen"),
            new System.Data.OleDb.OleDbParameter("IDUrlaub", System.Data.OleDb.OleDbType.Guid, 0, "IDUrlaub"),
            new System.Data.OleDb.OleDbParameter("Fallnummer", System.Data.OleDb.OleDbType.Double, 0, "Fallnummer"),
            new System.Data.OleDb.OleDbParameter("Gruppenkennzahl", System.Data.OleDb.OleDbType.VarChar, 0, "Gruppenkennzahl"),
            new System.Data.OleDb.OleDbParameter("Verfuegungsdatum", System.Data.OleDb.OleDbType.Date, 16, "Verfuegungsdatum"),
            new System.Data.OleDb.OleDbParameter("Bermerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bermerkung"),
            new System.Data.OleDb.OleDbParameter("Besuchsregelung", System.Data.OleDb.OleDbType.VarChar, 0, "Besuchsregelung"),
            new System.Data.OleDb.OleDbParameter("Postregelung", System.Data.OleDb.OleDbType.VarChar, 0, "Postregelung"),
            new System.Data.OleDb.OleDbParameter("SonstigeRegelung", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeRegelung"),
            new System.Data.OleDb.OleDbParameter("Erwartungen", System.Data.OleDb.OleDbType.VarChar, 0, "Erwartungen"),
            new System.Data.OleDb.OleDbParameter("IDErstkontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDErstkontakt"),
            new System.Data.OleDb.OleDbParameter("Gewicht", System.Data.OleDb.OleDbType.Double, 0, "Gewicht"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, "NaechsteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"),
            new System.Data.OleDb.OleDbParameter("TaschengeldSollstand", System.Data.OleDb.OleDbType.Double, 0, "TaschengeldSollstand"),
            new System.Data.OleDb.OleDbParameter("TaschegeldVortragDatum", System.Data.OleDb.OleDbType.Date, 16, "TaschegeldVortragDatum"),
            new System.Data.OleDb.OleDbParameter("TaschengeldVortragBetrag", System.Data.OleDb.OleDbType.Double, 0, "TaschengeldVortragBetrag"),
            new System.Data.OleDb.OleDbParameter("Ausgleichszahlung", System.Data.OleDb.OleDbType.Double, 0, "Ausgleichszahlung"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daHistoryByPatient
            // 
            this.daHistoryByPatient.SelectCommand = this.oleDbCommand1;
            this.daHistoryByPatient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "History", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Entlassungszeitpunkt", "Entlassungszeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Entlassungsbemerkung", "Entlassungsbemerkung")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = resources.GetString("oleDbInsertCommand2.CommandText");
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("IDAufenthaltVerlauf", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthaltVerlauf"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Aufnahme", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Aufnahme"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Entlassung", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Entlassung"),
            new System.Data.OleDb.OleDbParameter("IDEinrichtung_Aufnahme", System.Data.OleDb.OleDbType.Guid, 0, "IDEinrichtung_Aufnahme"),
            new System.Data.OleDb.OleDbParameter("IDEinrichtung_Entlassung", System.Data.OleDb.OleDbType.Guid, 0, "IDEinrichtung_Entlassung"),
            new System.Data.OleDb.OleDbParameter("Aufnahmezeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "Aufnahmezeitpunkt"),
            new System.Data.OleDb.OleDbParameter("Entlassungszeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "Entlassungszeitpunkt"),
            new System.Data.OleDb.OleDbParameter("AufnahmeArt", System.Data.OleDb.OleDbType.Integer, 0, "AufnahmeArt"),
            new System.Data.OleDb.OleDbParameter("BegleitungVon", System.Data.OleDb.OleDbType.VarChar, 0, "BegleitungVon"),
            new System.Data.OleDb.OleDbParameter("Entlassungsbemerkung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Entlassungsbemerkung"),
            new System.Data.OleDb.OleDbParameter("SomatischeAuff", System.Data.OleDb.OleDbType.VarChar, 0, "SomatischeAuff"),
            new System.Data.OleDb.OleDbParameter("PsychischeAuff", System.Data.OleDb.OleDbType.VarChar, 0, "PsychischeAuff"),
            new System.Data.OleDb.OleDbParameter("VerhaltenAufnahme", System.Data.OleDb.OleDbType.VarChar, 0, "VerhaltenAufnahme"),
            new System.Data.OleDb.OleDbParameter("SonstigeBesonderheiten", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeBesonderheiten"),
            new System.Data.OleDb.OleDbParameter("SofortMassnahmen", System.Data.OleDb.OleDbType.VarChar, 0, "SofortMassnahmen"),
            new System.Data.OleDb.OleDbParameter("IDUrlaub", System.Data.OleDb.OleDbType.Guid, 0, "IDUrlaub"),
            new System.Data.OleDb.OleDbParameter("Fallnummer", System.Data.OleDb.OleDbType.Double, 0, "Fallnummer"),
            new System.Data.OleDb.OleDbParameter("Gruppenkennzahl", System.Data.OleDb.OleDbType.VarChar, 0, "Gruppenkennzahl"),
            new System.Data.OleDb.OleDbParameter("Verfuegungsdatum", System.Data.OleDb.OleDbType.Date, 16, "Verfuegungsdatum"),
            new System.Data.OleDb.OleDbParameter("Bermerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bermerkung"),
            new System.Data.OleDb.OleDbParameter("Besuchsregelung", System.Data.OleDb.OleDbType.VarChar, 0, "Besuchsregelung"),
            new System.Data.OleDb.OleDbParameter("Postregelung", System.Data.OleDb.OleDbType.VarChar, 0, "Postregelung"),
            new System.Data.OleDb.OleDbParameter("SonstigeRegelung", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeRegelung"),
            new System.Data.OleDb.OleDbParameter("Erwartungen", System.Data.OleDb.OleDbType.VarChar, 0, "Erwartungen"),
            new System.Data.OleDb.OleDbParameter("IDErstkontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDErstkontakt"),
            new System.Data.OleDb.OleDbParameter("Gewicht", System.Data.OleDb.OleDbType.Double, 0, "Gewicht"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, "NaechsteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"),
            new System.Data.OleDb.OleDbParameter("TaschengeldSollstand", System.Data.OleDb.OleDbType.Double, 0, "TaschengeldSollstand"),
            new System.Data.OleDb.OleDbParameter("TaschegeldVortragDatum", System.Data.OleDb.OleDbType.Date, 16, "TaschegeldVortragDatum"),
            new System.Data.OleDb.OleDbParameter("TaschengeldVortragBetrag", System.Data.OleDb.OleDbType.Double, 0, "TaschengeldVortragBetrag"),
            new System.Data.OleDb.OleDbParameter("Ausgleichszahlung", System.Data.OleDb.OleDbType.Double, 0, "Ausgleichszahlung"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("IDAufenthaltVerlauf", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthaltVerlauf"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Aufnahme", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Aufnahme"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Entlassung", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Entlassung"),
            new System.Data.OleDb.OleDbParameter("IDEinrichtung_Aufnahme", System.Data.OleDb.OleDbType.Guid, 0, "IDEinrichtung_Aufnahme"),
            new System.Data.OleDb.OleDbParameter("IDEinrichtung_Entlassung", System.Data.OleDb.OleDbType.Guid, 0, "IDEinrichtung_Entlassung"),
            new System.Data.OleDb.OleDbParameter("Aufnahmezeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "Aufnahmezeitpunkt"),
            new System.Data.OleDb.OleDbParameter("Entlassungszeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "Entlassungszeitpunkt"),
            new System.Data.OleDb.OleDbParameter("AufnahmeArt", System.Data.OleDb.OleDbType.Integer, 0, "AufnahmeArt"),
            new System.Data.OleDb.OleDbParameter("BegleitungVon", System.Data.OleDb.OleDbType.VarChar, 0, "BegleitungVon"),
            new System.Data.OleDb.OleDbParameter("Entlassungsbemerkung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Entlassungsbemerkung"),
            new System.Data.OleDb.OleDbParameter("SomatischeAuff", System.Data.OleDb.OleDbType.VarChar, 0, "SomatischeAuff"),
            new System.Data.OleDb.OleDbParameter("PsychischeAuff", System.Data.OleDb.OleDbType.VarChar, 0, "PsychischeAuff"),
            new System.Data.OleDb.OleDbParameter("VerhaltenAufnahme", System.Data.OleDb.OleDbType.VarChar, 0, "VerhaltenAufnahme"),
            new System.Data.OleDb.OleDbParameter("SonstigeBesonderheiten", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeBesonderheiten"),
            new System.Data.OleDb.OleDbParameter("SofortMassnahmen", System.Data.OleDb.OleDbType.VarChar, 0, "SofortMassnahmen"),
            new System.Data.OleDb.OleDbParameter("IDUrlaub", System.Data.OleDb.OleDbType.Guid, 0, "IDUrlaub"),
            new System.Data.OleDb.OleDbParameter("Fallnummer", System.Data.OleDb.OleDbType.Double, 0, "Fallnummer"),
            new System.Data.OleDb.OleDbParameter("Gruppenkennzahl", System.Data.OleDb.OleDbType.VarChar, 0, "Gruppenkennzahl"),
            new System.Data.OleDb.OleDbParameter("Verfuegungsdatum", System.Data.OleDb.OleDbType.Date, 16, "Verfuegungsdatum"),
            new System.Data.OleDb.OleDbParameter("Bermerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bermerkung"),
            new System.Data.OleDb.OleDbParameter("Besuchsregelung", System.Data.OleDb.OleDbType.VarChar, 0, "Besuchsregelung"),
            new System.Data.OleDb.OleDbParameter("Postregelung", System.Data.OleDb.OleDbType.VarChar, 0, "Postregelung"),
            new System.Data.OleDb.OleDbParameter("SonstigeRegelung", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeRegelung"),
            new System.Data.OleDb.OleDbParameter("Erwartungen", System.Data.OleDb.OleDbType.VarChar, 0, "Erwartungen"),
            new System.Data.OleDb.OleDbParameter("IDErstkontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDErstkontakt"),
            new System.Data.OleDb.OleDbParameter("Gewicht", System.Data.OleDb.OleDbType.Double, 0, "Gewicht"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, "NaechsteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"),
            new System.Data.OleDb.OleDbParameter("TaschengeldSollstand", System.Data.OleDb.OleDbType.Double, 0, "TaschengeldSollstand"),
            new System.Data.OleDb.OleDbParameter("TaschegeldVortragDatum", System.Data.OleDb.OleDbType.Date, 16, "TaschegeldVortragDatum"),
            new System.Data.OleDb.OleDbParameter("TaschengeldVortragBetrag", System.Data.OleDb.OleDbType.Double, 0, "TaschengeldVortragBetrag"),
            new System.Data.OleDb.OleDbParameter("Ausgleichszahlung", System.Data.OleDb.OleDbType.Double, 0, "Ausgleichszahlung"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM [Aufenthalt] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daAufenthaltByID
            // 
            this.daAufenthaltByID.DeleteCommand = this.oleDbDeleteCommand2;
            this.daAufenthaltByID.InsertCommand = this.oleDbInsertCommand2;
            this.daAufenthaltByID.SelectCommand = this.oleDbSelectCommand3;
            this.daAufenthaltByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Aufenthalt", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDAufenthaltVerlauf", "IDAufenthaltVerlauf"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Aufnahme", "IDBenutzer_Aufnahme"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Entlassung", "IDBenutzer_Entlassung"),
                        new System.Data.Common.DataColumnMapping("IDEinrichtung_Aufnahme", "IDEinrichtung_Aufnahme"),
                        new System.Data.Common.DataColumnMapping("IDEinrichtung_Entlassung", "IDEinrichtung_Entlassung"),
                        new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Entlassungszeitpunkt", "Entlassungszeitpunkt"),
                        new System.Data.Common.DataColumnMapping("AufnahmeArt", "AufnahmeArt"),
                        new System.Data.Common.DataColumnMapping("BegleitungVon", "BegleitungVon"),
                        new System.Data.Common.DataColumnMapping("Entlassungsbemerkung", "Entlassungsbemerkung"),
                        new System.Data.Common.DataColumnMapping("SomatischeAuff", "SomatischeAuff"),
                        new System.Data.Common.DataColumnMapping("PsychischeAuff", "PsychischeAuff"),
                        new System.Data.Common.DataColumnMapping("VerhaltenAufnahme", "VerhaltenAufnahme"),
                        new System.Data.Common.DataColumnMapping("SonstigeBesonderheiten", "SonstigeBesonderheiten"),
                        new System.Data.Common.DataColumnMapping("SofortMassnahmen", "SofortMassnahmen"),
                        new System.Data.Common.DataColumnMapping("IDUrlaub", "IDUrlaub"),
                        new System.Data.Common.DataColumnMapping("BarcodeID", "BarcodeID"),
                        new System.Data.Common.DataColumnMapping("Fallnummer", "Fallnummer"),
                        new System.Data.Common.DataColumnMapping("Gruppenkennzahl", "Gruppenkennzahl"),
                        new System.Data.Common.DataColumnMapping("Verfuegungsdatum", "Verfuegungsdatum"),
                        new System.Data.Common.DataColumnMapping("Bermerkung", "Bermerkung"),
                        new System.Data.Common.DataColumnMapping("Besuchsregelung", "Besuchsregelung"),
                        new System.Data.Common.DataColumnMapping("Postregelung", "Postregelung"),
                        new System.Data.Common.DataColumnMapping("SonstigeRegelung", "SonstigeRegelung"),
                        new System.Data.Common.DataColumnMapping("Erwartungen", "Erwartungen"),
                        new System.Data.Common.DataColumnMapping("IDErstkontakt", "IDErstkontakt"),
                        new System.Data.Common.DataColumnMapping("Gewicht", "Gewicht"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"),
                        new System.Data.Common.DataColumnMapping("TaschengeldSollstand", "TaschengeldSollstand"),
                        new System.Data.Common.DataColumnMapping("TaschegeldVortragDatum", "TaschegeldVortragDatum"),
                        new System.Data.Common.DataColumnMapping("TaschengeldVortragBetrag", "TaschengeldVortragBetrag"),
                        new System.Data.Common.DataColumnMapping("Ausgleichszahlung", "Ausgleichszahlung"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich")})});
            this.daAufenthaltByID.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // dsAufenthalt1
            // 
            this.dsAufenthalt1.DataSetName = "dsAufenthalt";
            this.dsAufenthalt1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsAufenthalt1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daAktuellAufenthaltByPatient
            // 
            this.daAktuellAufenthaltByPatient.DeleteCommand = this.oleDbCommand2;
            this.daAktuellAufenthaltByPatient.SelectCommand = this.oleDbCommand4;
            this.daAktuellAufenthaltByPatient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Aufenthalt", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich")})});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "DELETE FROM [Aufenthalt] WHERE (([ID] = ?) AND ((? = 1 AND [IDPatient] IS NULL) O" +
    "R ([IDPatient] = ?)) AND ((? = 1 AND [Aufnahmezeitpunkt] IS NULL) OR ([Aufnahmez" +
    "eitpunkt] = ?)))";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDPatient", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPatient", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Aufnahmezeitpunkt", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Aufnahmezeitpunkt", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Aufnahmezeitpunkt", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Aufnahmezeitpunkt", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "SELECT        ID, IDPatient, Aufnahmezeitpunkt, IDKlinik, IDBereich\r\nFROM        " +
    "    Aufenthalt\r\nWHERE        (IDPatient = ?) AND (Entlassungszeitpunkt IS NULL)\r" +
    "\nORDER BY Aufnahmezeitpunkt DESC";
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            ((System.ComponentModel.ISupportInitialize)(this.dsAufenthalt1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daAufenthaltByID;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen Aufenthalt erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
			ITEM.AddAufenthaltRow(Guid.NewGuid(), Guid.Empty, Guid.Empty, Guid.Empty,
                Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, DateTime.Now, DateTime.MinValue, 0, "", "", "", "", "", "", "",
                Guid.Empty, 0, "", DateTime.Now, "", "", "", "", "", Guid.Empty, 0, DateTime.Now, "", 0, DateTime.Now, 0, 0.0, Guid.Empty, Guid.Empty);

			ITEM[0].SetEntlassungszeitpunktNull();
			ITEM[0].SetIDBenutzer_EntlassungNull();
			ITEM[0].SetIDEinrichtung_AufnahmeNull();
			ITEM[0].SetIDEinrichtung_EntlassungNull();
			ITEM[0].SetIDUrlaubNull();
            ITEM[0].SetVerfuegungsdatumNull();
            ITEM[0].SetFallnummerNull();
            ITEM[0].SetGewichtNull();
            ITEM[0].SetNaechsteEvaluierungNull();
            ITEM[0].SetTaschegeldVortragDatumNull();
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsAufenthalt.AufenthaltDataTable ITEM
		{
			get	{	return dsAufenthalt1.Aufenthalt;	}
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
		/// Aufenthalte für Patienten ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public dsAufenthalt.AufenthaltDataTable ByPatient(Guid id)
		{
			dsAufenthalt ds = new dsAufenthalt();
			daAufenthaltByPatient.SelectCommand.Parameters[0].Value = id;
			DataBase.Fill(daAufenthaltByPatient, ds.Aufenthalt);
			return ds.Aufenthalt;
		}

        public DateTime  aktAufenthaltPatient(Guid id)
        {
            DataTable dt = new DataTable();
            daAktuellAufenthaltByPatient.SelectCommand.Parameters[0].Value = id;
            DataBase.Fill(daAktuellAufenthaltByPatient, dt);
            if (dt.Rows.Count >= 1)
            {
                return (DateTime)dt.Rows[0]["Aufnahmezeitpunkt"];
            }
            else
            {
                return new DateTime(1900, 1, 1) ;
            }
        }


		//----------------------------------------------------------------------------
		/// <summary>
		/// vergangene Aufenthalte für Patienten ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public dsAufenthalt.HistoryDataTable HistoryByPatient(Guid id)
		{
			dsAufenthalt ds = new dsAufenthalt();
			daHistoryByPatient.SelectCommand.Parameters[0].Value = id;
			DataBase.Fill(daHistoryByPatient, ds.History);
			return ds.History;
		}
        public bool updateAufnahmeEntlassung(Guid IDAufenthalt, DateTime Aufnahmezeitpunkt, DateTime Entlassungszeitpunkt)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmd.Connection = RBU.DataBase.CONNECTION;
            cmd.CommandText = "UPDATE  Aufenthalt  SET  Aufnahmezeitpunkt = ?, Entlassungszeitpunkt = ?  WHERE ID = ? ";
            cmd.Parameters.Add("Aufnahmezeitpunkt", System.Data.OleDb.OleDbType.Date, 8, "Aufnahmezeitpunkt").Value = Aufnahmezeitpunkt;
            object oEntlassungszeitpunkt = Entlassungszeitpunkt.Year == 1900 ? System.DBNull.Value  :(object) Entlassungszeitpunkt;
            cmd.Parameters.Add("Entlassungszeitpunkt", System.Data.OleDb.OleDbType.Date, 8, "Entlassungszeitpunkt").Value = oEntlassungszeitpunkt;
            cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = IDAufenthalt;
            cmd.ExecuteNonQuery();
            return true;
        }

	}
}
