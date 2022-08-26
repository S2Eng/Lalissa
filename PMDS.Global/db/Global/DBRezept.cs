//----------------------------------------------------------------------------
/// <summary>
///	DBRezept.cs
/// Erstellt am:	29.8.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Collections.Generic;
using RBU;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;
using System.Data.SqlClient;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die Rezepte.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
    public class DBRezept : System.ComponentModel.Component
	{
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private PMDS.Data.Global.dsRezeptEintrag dsRezeptEintrag1;
        private OleDbDataAdapter daRezeptEintragByAufenthalt;
        private OleDbCommand oleDbCommand1;
        private OleDbDataAdapter daKlientenListeByMedikament; ///{{{eng}}}04.10.2007
        private OleDbCommand oleDbCommand2;						///{{{eng}}}04.10.2007
        private dsKlientenListeByMedikament dsKlientenListeByMedikament1;
        private OleDbCommand oleDbSelectCommand1;
        private OleDbCommand oleDbInsertCommand1;
        private OleDbCommand oleDbUpdateCommand1;
        private OleDbCommand oleDbDeleteCommand1;
        public OleDbDataAdapter daRezeptEintrag;
        private OleDbCommand oleDbDeleteCommand;
        private OleDbCommand oleDbInsertCommand;
        private OleDbCommand oleDbUpdateCommand;

        ///{{{eng}}}04.10.2007
        private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBRezept()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBRezept));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daRezeptEintragByAufenthalt = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.daKlientenListeByMedikament = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.dsKlientenListeByMedikament1 = new PMDS.Global.db.Global.dsKlientenListeByMedikament();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daRezeptEintrag = new System.Data.OleDb.OleDbDataAdapter();
            this.dsRezeptEintrag1 = new PMDS.Data.Global.dsRezeptEintrag();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenListeByMedikament1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRezeptEintrag1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=sty041;Integrated Security=SSPI;Initial Catalog=PM" +
    "DS_DemoGross";
            // 
            // daRezeptEintragByAufenthalt
            // 
            this.daRezeptEintragByAufenthalt.DeleteCommand = this.oleDbDeleteCommand;
            this.daRezeptEintragByAufenthalt.InsertCommand = this.oleDbInsertCommand;
            this.daRezeptEintragByAufenthalt.SelectCommand = this.oleDbCommand1;
            this.daRezeptEintragByAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "RezeptEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDMedikament", "IDMedikament"),
                        new System.Data.Common.DataColumnMapping("AbzugebenVon", "AbzugebenVon"),
                        new System.Data.Common.DataColumnMapping("AbzugebenBis", "AbzugebenBis"),
                        new System.Data.Common.DataColumnMapping("BeaufsichtigungJN", "BeaufsichtigungJN"),
                        new System.Data.Common.DataColumnMapping("ZP0", "ZP0"),
                        new System.Data.Common.DataColumnMapping("ZP1", "ZP1"),
                        new System.Data.Common.DataColumnMapping("ZP2", "ZP2"),
                        new System.Data.Common.DataColumnMapping("ZP3", "ZP3"),
                        new System.Data.Common.DataColumnMapping("ZP4", "ZP4"),
                        new System.Data.Common.DataColumnMapping("ZP5", "ZP5"),
                        new System.Data.Common.DataColumnMapping("ZP6", "ZP6"),
                        new System.Data.Common.DataColumnMapping("Einheit", "Einheit"),
                        new System.Data.Common.DataColumnMapping("Intervall", "Intervall"),
                        new System.Data.Common.DataColumnMapping("Wochentage", "Wochentage"),
                        new System.Data.Common.DataColumnMapping("BedarfsMedikationJN", "BedarfsMedikationJN"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("Herrichten", "Herrichten"),
                        new System.Data.Common.DataColumnMapping("AerztlichevorbereitungJN", "AerztlichevorbereitungJN"),
                        new System.Data.Common.DataColumnMapping("Verabreichungsart", "Verabreichungsart"),
                        new System.Data.Common.DataColumnMapping("Applikationsform", "Applikationsform"),
                        new System.Data.Common.DataColumnMapping("Wiederholungstyp", "Wiederholungstyp"),
                        new System.Data.Common.DataColumnMapping("Wiederholungseinheit", "Wiederholungseinheit"),
                        new System.Data.Common.DataColumnMapping("Wiederholungswert", "Wiederholungswert"),
                        new System.Data.Common.DataColumnMapping("StandardzeitenJN", "StandardzeitenJN"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt0", "Zeitpunkt0"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt1", "Zeitpunkt1"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt2", "Zeitpunkt2"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt3", "Zeitpunkt3"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt4", "Zeitpunkt4"),
                        new System.Data.Common.DataColumnMapping("Packunggroesse", "Packunggroesse"),
                        new System.Data.Common.DataColumnMapping("Rezeptdaten", "Rezeptdaten"),
                        new System.Data.Common.DataColumnMapping("Packungeinheit", "Packungeinheit"),
                        new System.Data.Common.DataColumnMapping("BestellenJN", "BestellenJN"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDAerzte", "IDAerzte"),
                        new System.Data.Common.DataColumnMapping("AusstellungsDatum", "AusstellungsDatum"),
                        new System.Data.Common.DataColumnMapping("DosierungASString", "DosierungASString"),
                        new System.Data.Common.DataColumnMapping("Packungsanzahl", "Packungsanzahl"),
                        new System.Data.Common.DataColumnMapping("ZuletztBestelltAm", "ZuletztBestelltAm"),
                        new System.Data.Common.DataColumnMapping("IDAerzteGeaendert", "IDAerzteGeaendert"),
                        new System.Data.Common.DataColumnMapping("IDArztAbgesetzt", "IDArztAbgesetzt"),
                        new System.Data.Common.DataColumnMapping("ZuletztBestelltVon", "ZuletztBestelltVon"),
                        new System.Data.Common.DataColumnMapping("HAGPflichtigJN", "HAGPflichtigJN"),
                        new System.Data.Common.DataColumnMapping("lstMedDaten", "lstMedDaten"),
                        new System.Data.Common.DataColumnMapping("ZeitpunktBlisterliste", "ZeitpunktBlisterliste"),
                        new System.Data.Common.DataColumnMapping("NumberMedDaten", "NumberMedDaten"),
                        new System.Data.Common.DataColumnMapping("lstWunden", "lstWunden"),
                        new System.Data.Common.DataColumnMapping("NumberWunden", "NumberWunden")})});
            this.daRezeptEintragByAufenthalt.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [RezeptEintrag] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = resources.GetString("oleDbInsertCommand.CommandText");
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDMedikament", System.Data.OleDb.OleDbType.Guid, 0, "IDMedikament"),
            new System.Data.OleDb.OleDbParameter("AbzugebenVon", System.Data.OleDb.OleDbType.Date, 16, "AbzugebenVon"),
            new System.Data.OleDb.OleDbParameter("AbzugebenBis", System.Data.OleDb.OleDbType.Date, 16, "AbzugebenBis"),
            new System.Data.OleDb.OleDbParameter("BeaufsichtigungJN", System.Data.OleDb.OleDbType.Boolean, 0, "BeaufsichtigungJN"),
            new System.Data.OleDb.OleDbParameter("ZP0", System.Data.OleDb.OleDbType.Double, 0, "ZP0"),
            new System.Data.OleDb.OleDbParameter("ZP1", System.Data.OleDb.OleDbType.Double, 0, "ZP1"),
            new System.Data.OleDb.OleDbParameter("ZP2", System.Data.OleDb.OleDbType.Double, 0, "ZP2"),
            new System.Data.OleDb.OleDbParameter("ZP3", System.Data.OleDb.OleDbType.Double, 0, "ZP3"),
            new System.Data.OleDb.OleDbParameter("ZP4", System.Data.OleDb.OleDbType.Double, 0, "ZP4"),
            new System.Data.OleDb.OleDbParameter("ZP5", System.Data.OleDb.OleDbType.Double, 0, "ZP5"),
            new System.Data.OleDb.OleDbParameter("ZP6", System.Data.OleDb.OleDbType.Double, 0, "ZP6"),
            new System.Data.OleDb.OleDbParameter("Einheit", System.Data.OleDb.OleDbType.VarChar, 0, "Einheit"),
            new System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.Integer, 0, "Intervall"),
            new System.Data.OleDb.OleDbParameter("Wochentage", System.Data.OleDb.OleDbType.Integer, 0, "Wochentage"),
            new System.Data.OleDb.OleDbParameter("BedarfsMedikationJN", System.Data.OleDb.OleDbType.Boolean, 0, "BedarfsMedikationJN"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("Herrichten", System.Data.OleDb.OleDbType.Integer, 0, "Herrichten"),
            new System.Data.OleDb.OleDbParameter("AerztlichevorbereitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "AerztlichevorbereitungJN"),
            new System.Data.OleDb.OleDbParameter("Verabreichungsart", System.Data.OleDb.OleDbType.Integer, 0, "Verabreichungsart"),
            new System.Data.OleDb.OleDbParameter("Applikationsform", System.Data.OleDb.OleDbType.VarChar, 0, "Applikationsform"),
            new System.Data.OleDb.OleDbParameter("Wiederholungstyp", System.Data.OleDb.OleDbType.Integer, 0, "Wiederholungstyp"),
            new System.Data.OleDb.OleDbParameter("Wiederholungseinheit", System.Data.OleDb.OleDbType.Integer, 0, "Wiederholungseinheit"),
            new System.Data.OleDb.OleDbParameter("Wiederholungswert", System.Data.OleDb.OleDbType.Double, 0, "Wiederholungswert"),
            new System.Data.OleDb.OleDbParameter("StandardzeitenJN", System.Data.OleDb.OleDbType.Boolean, 0, "StandardzeitenJN"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt0", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt0"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt1", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt1"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt2", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt2"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt3", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt3"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt4", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt4"),
            new System.Data.OleDb.OleDbParameter("Packunggroesse", System.Data.OleDb.OleDbType.Double, 0, "Packunggroesse"),
            new System.Data.OleDb.OleDbParameter("Rezeptdaten", System.Data.OleDb.OleDbType.VarChar, 0, "Rezeptdaten"),
            new System.Data.OleDb.OleDbParameter("Packungeinheit", System.Data.OleDb.OleDbType.VarChar, 0, "Packungeinheit"),
            new System.Data.OleDb.OleDbParameter("BestellenJN", System.Data.OleDb.OleDbType.Boolean, 0, "BestellenJN"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDAerzte", System.Data.OleDb.OleDbType.Guid, 0, "IDAerzte"),
            new System.Data.OleDb.OleDbParameter("AusstellungsDatum", System.Data.OleDb.OleDbType.Date, 16, "AusstellungsDatum"),
            new System.Data.OleDb.OleDbParameter("DosierungASString", System.Data.OleDb.OleDbType.VarChar, 0, "DosierungASString"),
            new System.Data.OleDb.OleDbParameter("Packungsanzahl", System.Data.OleDb.OleDbType.Integer, 0, "Packungsanzahl"),
            new System.Data.OleDb.OleDbParameter("ZuletztBestelltAm", System.Data.OleDb.OleDbType.Date, 16, "ZuletztBestelltAm"),
            new System.Data.OleDb.OleDbParameter("IDAerzteGeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDAerzteGeaendert"),
            new System.Data.OleDb.OleDbParameter("IDArztAbgesetzt", System.Data.OleDb.OleDbType.Guid, 0, "IDArztAbgesetzt"),
            new System.Data.OleDb.OleDbParameter("ZuletztBestelltVon", System.Data.OleDb.OleDbType.Guid, 0, "ZuletztBestelltVon"),
            new System.Data.OleDb.OleDbParameter("HAGPflichtigJN", System.Data.OleDb.OleDbType.Boolean, 0, "HAGPflichtigJN"),
            new System.Data.OleDb.OleDbParameter("lstMedDaten", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstMedDaten"),
            new System.Data.OleDb.OleDbParameter("ZeitpunktBlisterliste", System.Data.OleDb.OleDbType.Date, 16, "ZeitpunktBlisterliste"),
            new System.Data.OleDb.OleDbParameter("NumberMedDaten", System.Data.OleDb.OleDbType.Integer, 0, "NumberMedDaten"),
            new System.Data.OleDb.OleDbParameter("lstWunden", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstWunden"),
            new System.Data.OleDb.OleDbParameter("NumberWunden", System.Data.OleDb.OleDbType.Integer, 0, "NumberWunden")});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDMedikament", System.Data.OleDb.OleDbType.Guid, 0, "IDMedikament"),
            new System.Data.OleDb.OleDbParameter("AbzugebenVon", System.Data.OleDb.OleDbType.Date, 16, "AbzugebenVon"),
            new System.Data.OleDb.OleDbParameter("AbzugebenBis", System.Data.OleDb.OleDbType.Date, 16, "AbzugebenBis"),
            new System.Data.OleDb.OleDbParameter("BeaufsichtigungJN", System.Data.OleDb.OleDbType.Boolean, 0, "BeaufsichtigungJN"),
            new System.Data.OleDb.OleDbParameter("ZP0", System.Data.OleDb.OleDbType.Double, 0, "ZP0"),
            new System.Data.OleDb.OleDbParameter("ZP1", System.Data.OleDb.OleDbType.Double, 0, "ZP1"),
            new System.Data.OleDb.OleDbParameter("ZP2", System.Data.OleDb.OleDbType.Double, 0, "ZP2"),
            new System.Data.OleDb.OleDbParameter("ZP3", System.Data.OleDb.OleDbType.Double, 0, "ZP3"),
            new System.Data.OleDb.OleDbParameter("ZP4", System.Data.OleDb.OleDbType.Double, 0, "ZP4"),
            new System.Data.OleDb.OleDbParameter("ZP5", System.Data.OleDb.OleDbType.Double, 0, "ZP5"),
            new System.Data.OleDb.OleDbParameter("ZP6", System.Data.OleDb.OleDbType.Double, 0, "ZP6"),
            new System.Data.OleDb.OleDbParameter("Einheit", System.Data.OleDb.OleDbType.VarChar, 0, "Einheit"),
            new System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.Integer, 0, "Intervall"),
            new System.Data.OleDb.OleDbParameter("Wochentage", System.Data.OleDb.OleDbType.Integer, 0, "Wochentage"),
            new System.Data.OleDb.OleDbParameter("BedarfsMedikationJN", System.Data.OleDb.OleDbType.Boolean, 0, "BedarfsMedikationJN"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("Herrichten", System.Data.OleDb.OleDbType.Integer, 0, "Herrichten"),
            new System.Data.OleDb.OleDbParameter("AerztlichevorbereitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "AerztlichevorbereitungJN"),
            new System.Data.OleDb.OleDbParameter("Verabreichungsart", System.Data.OleDb.OleDbType.Integer, 0, "Verabreichungsart"),
            new System.Data.OleDb.OleDbParameter("Applikationsform", System.Data.OleDb.OleDbType.VarChar, 0, "Applikationsform"),
            new System.Data.OleDb.OleDbParameter("Wiederholungstyp", System.Data.OleDb.OleDbType.Integer, 0, "Wiederholungstyp"),
            new System.Data.OleDb.OleDbParameter("Wiederholungseinheit", System.Data.OleDb.OleDbType.Integer, 0, "Wiederholungseinheit"),
            new System.Data.OleDb.OleDbParameter("Wiederholungswert", System.Data.OleDb.OleDbType.Double, 0, "Wiederholungswert"),
            new System.Data.OleDb.OleDbParameter("StandardzeitenJN", System.Data.OleDb.OleDbType.Boolean, 0, "StandardzeitenJN"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt0", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt0"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt1", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt1"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt2", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt2"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt3", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt3"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt4", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt4"),
            new System.Data.OleDb.OleDbParameter("Packunggroesse", System.Data.OleDb.OleDbType.Double, 0, "Packunggroesse"),
            new System.Data.OleDb.OleDbParameter("Rezeptdaten", System.Data.OleDb.OleDbType.VarChar, 0, "Rezeptdaten"),
            new System.Data.OleDb.OleDbParameter("Packungeinheit", System.Data.OleDb.OleDbType.VarChar, 0, "Packungeinheit"),
            new System.Data.OleDb.OleDbParameter("BestellenJN", System.Data.OleDb.OleDbType.Boolean, 0, "BestellenJN"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDAerzte", System.Data.OleDb.OleDbType.Guid, 0, "IDAerzte"),
            new System.Data.OleDb.OleDbParameter("AusstellungsDatum", System.Data.OleDb.OleDbType.Date, 16, "AusstellungsDatum"),
            new System.Data.OleDb.OleDbParameter("DosierungASString", System.Data.OleDb.OleDbType.VarChar, 0, "DosierungASString"),
            new System.Data.OleDb.OleDbParameter("Packungsanzahl", System.Data.OleDb.OleDbType.Integer, 0, "Packungsanzahl"),
            new System.Data.OleDb.OleDbParameter("ZuletztBestelltAm", System.Data.OleDb.OleDbType.Date, 16, "ZuletztBestelltAm"),
            new System.Data.OleDb.OleDbParameter("IDAerzteGeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDAerzteGeaendert"),
            new System.Data.OleDb.OleDbParameter("IDArztAbgesetzt", System.Data.OleDb.OleDbType.Guid, 0, "IDArztAbgesetzt"),
            new System.Data.OleDb.OleDbParameter("ZuletztBestelltVon", System.Data.OleDb.OleDbType.Guid, 0, "ZuletztBestelltVon"),
            new System.Data.OleDb.OleDbParameter("HAGPflichtigJN", System.Data.OleDb.OleDbType.Boolean, 0, "HAGPflichtigJN"),
            new System.Data.OleDb.OleDbParameter("lstMedDaten", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstMedDaten"),
            new System.Data.OleDb.OleDbParameter("ZeitpunktBlisterliste", System.Data.OleDb.OleDbType.Date, 16, "ZeitpunktBlisterliste"),
            new System.Data.OleDb.OleDbParameter("NumberMedDaten", System.Data.OleDb.OleDbType.Integer, 0, "NumberMedDaten"),
            new System.Data.OleDb.OleDbParameter("lstWunden", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstWunden"),
            new System.Data.OleDb.OleDbParameter("NumberWunden", System.Data.OleDb.OleDbType.Integer, 0, "NumberWunden"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daKlientenListeByMedikament
            // 
            this.daKlientenListeByMedikament.SelectCommand = this.oleDbCommand2;
            this.daKlientenListeByMedikament.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDMedikament", "IDMedikament"),
                        new System.Data.Common.DataColumnMapping("AbzugebenVon", "AbzugebenVon"),
                        new System.Data.Common.DataColumnMapping("AbzugebenBis", "AbzugebenBis"),
                        new System.Data.Common.DataColumnMapping("IstVorbereitet", "IstVorbereitet"),
                        new System.Data.Common.DataColumnMapping("Packunggroesse", "Packunggroesse"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("KlientAbteilung", "KlientAbteilung"),
                        new System.Data.Common.DataColumnMapping("Medikament", "Medikament"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt")})});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDMedikament", System.Data.OleDb.OleDbType.Guid, 16, "IDMedikament"),
            new System.Data.OleDb.OleDbParameter("AbzugebenBis", System.Data.OleDb.OleDbType.Date, 16, "AbzugebenBis"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});
            // 
            // dsKlientenListeByMedikament1
            // 
            this.dsKlientenListeByMedikament1.DataSetName = "dsKlientenListeByMedikament";
            this.dsKlientenListeByMedikament1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDMedikament", System.Data.OleDb.OleDbType.Guid, 0, "IDMedikament"),
            new System.Data.OleDb.OleDbParameter("AbzugebenVon", System.Data.OleDb.OleDbType.Date, 16, "AbzugebenVon"),
            new System.Data.OleDb.OleDbParameter("AbzugebenBis", System.Data.OleDb.OleDbType.Date, 16, "AbzugebenBis"),
            new System.Data.OleDb.OleDbParameter("BeaufsichtigungJN", System.Data.OleDb.OleDbType.Boolean, 0, "BeaufsichtigungJN"),
            new System.Data.OleDb.OleDbParameter("ZP0", System.Data.OleDb.OleDbType.Double, 0, "ZP0"),
            new System.Data.OleDb.OleDbParameter("ZP1", System.Data.OleDb.OleDbType.Double, 0, "ZP1"),
            new System.Data.OleDb.OleDbParameter("ZP2", System.Data.OleDb.OleDbType.Double, 0, "ZP2"),
            new System.Data.OleDb.OleDbParameter("ZP3", System.Data.OleDb.OleDbType.Double, 0, "ZP3"),
            new System.Data.OleDb.OleDbParameter("ZP4", System.Data.OleDb.OleDbType.Double, 0, "ZP4"),
            new System.Data.OleDb.OleDbParameter("ZP5", System.Data.OleDb.OleDbType.Double, 0, "ZP5"),
            new System.Data.OleDb.OleDbParameter("ZP6", System.Data.OleDb.OleDbType.Double, 0, "ZP6"),
            new System.Data.OleDb.OleDbParameter("Einheit", System.Data.OleDb.OleDbType.VarChar, 0, "Einheit"),
            new System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.Integer, 0, "Intervall"),
            new System.Data.OleDb.OleDbParameter("Wochentage", System.Data.OleDb.OleDbType.Integer, 0, "Wochentage"),
            new System.Data.OleDb.OleDbParameter("BedarfsMedikationJN", System.Data.OleDb.OleDbType.Boolean, 0, "BedarfsMedikationJN"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("Herrichten", System.Data.OleDb.OleDbType.Integer, 0, "Herrichten"),
            new System.Data.OleDb.OleDbParameter("AerztlichevorbereitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "AerztlichevorbereitungJN"),
            new System.Data.OleDb.OleDbParameter("Verabreichungsart", System.Data.OleDb.OleDbType.Integer, 0, "Verabreichungsart"),
            new System.Data.OleDb.OleDbParameter("Applikationsform", System.Data.OleDb.OleDbType.VarChar, 0, "Applikationsform"),
            new System.Data.OleDb.OleDbParameter("Wiederholungstyp", System.Data.OleDb.OleDbType.Integer, 0, "Wiederholungstyp"),
            new System.Data.OleDb.OleDbParameter("Wiederholungseinheit", System.Data.OleDb.OleDbType.Integer, 0, "Wiederholungseinheit"),
            new System.Data.OleDb.OleDbParameter("Wiederholungswert", System.Data.OleDb.OleDbType.Double, 0, "Wiederholungswert"),
            new System.Data.OleDb.OleDbParameter("StandardzeitenJN", System.Data.OleDb.OleDbType.Boolean, 0, "StandardzeitenJN"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt0", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt0"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt1", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt1"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt2", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt2"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt3", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt3"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt4", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt4"),
            new System.Data.OleDb.OleDbParameter("Packunggroesse", System.Data.OleDb.OleDbType.Double, 0, "Packunggroesse"),
            new System.Data.OleDb.OleDbParameter("Rezeptdaten", System.Data.OleDb.OleDbType.VarChar, 0, "Rezeptdaten"),
            new System.Data.OleDb.OleDbParameter("Packungeinheit", System.Data.OleDb.OleDbType.VarChar, 0, "Packungeinheit"),
            new System.Data.OleDb.OleDbParameter("BestellenJN", System.Data.OleDb.OleDbType.Boolean, 0, "BestellenJN"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDAerzte", System.Data.OleDb.OleDbType.Guid, 0, "IDAerzte"),
            new System.Data.OleDb.OleDbParameter("AusstellungsDatum", System.Data.OleDb.OleDbType.Date, 16, "AusstellungsDatum"),
            new System.Data.OleDb.OleDbParameter("DosierungASString", System.Data.OleDb.OleDbType.VarChar, 0, "DosierungASString"),
            new System.Data.OleDb.OleDbParameter("Packungsanzahl", System.Data.OleDb.OleDbType.Integer, 0, "Packungsanzahl"),
            new System.Data.OleDb.OleDbParameter("ZuletztBestelltAm", System.Data.OleDb.OleDbType.Date, 16, "ZuletztBestelltAm"),
            new System.Data.OleDb.OleDbParameter("IDAerzteGeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDAerzteGeaendert"),
            new System.Data.OleDb.OleDbParameter("IDArztAbgesetzt", System.Data.OleDb.OleDbType.Guid, 0, "IDArztAbgesetzt"),
            new System.Data.OleDb.OleDbParameter("ZuletztBestelltVon", System.Data.OleDb.OleDbType.Guid, 0, "ZuletztBestelltVon"),
            new System.Data.OleDb.OleDbParameter("HAGPflichtigJN", System.Data.OleDb.OleDbType.Boolean, 0, "HAGPflichtigJN"),
            new System.Data.OleDb.OleDbParameter("lstMedDaten", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstMedDaten"),
            new System.Data.OleDb.OleDbParameter("ZeitpunktBlisterliste", System.Data.OleDb.OleDbType.Date, 16, "ZeitpunktBlisterliste"),
            new System.Data.OleDb.OleDbParameter("NumberMedDaten", System.Data.OleDb.OleDbType.Integer, 0, "NumberMedDaten"),
            new System.Data.OleDb.OleDbParameter("lstWunden", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstWunden"),
            new System.Data.OleDb.OleDbParameter("NumberWunden", System.Data.OleDb.OleDbType.Integer, 0, "NumberWunden")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDMedikament", System.Data.OleDb.OleDbType.Guid, 0, "IDMedikament"),
            new System.Data.OleDb.OleDbParameter("AbzugebenVon", System.Data.OleDb.OleDbType.Date, 16, "AbzugebenVon"),
            new System.Data.OleDb.OleDbParameter("AbzugebenBis", System.Data.OleDb.OleDbType.Date, 16, "AbzugebenBis"),
            new System.Data.OleDb.OleDbParameter("BeaufsichtigungJN", System.Data.OleDb.OleDbType.Boolean, 0, "BeaufsichtigungJN"),
            new System.Data.OleDb.OleDbParameter("ZP0", System.Data.OleDb.OleDbType.Double, 0, "ZP0"),
            new System.Data.OleDb.OleDbParameter("ZP1", System.Data.OleDb.OleDbType.Double, 0, "ZP1"),
            new System.Data.OleDb.OleDbParameter("ZP2", System.Data.OleDb.OleDbType.Double, 0, "ZP2"),
            new System.Data.OleDb.OleDbParameter("ZP3", System.Data.OleDb.OleDbType.Double, 0, "ZP3"),
            new System.Data.OleDb.OleDbParameter("ZP4", System.Data.OleDb.OleDbType.Double, 0, "ZP4"),
            new System.Data.OleDb.OleDbParameter("ZP5", System.Data.OleDb.OleDbType.Double, 0, "ZP5"),
            new System.Data.OleDb.OleDbParameter("ZP6", System.Data.OleDb.OleDbType.Double, 0, "ZP6"),
            new System.Data.OleDb.OleDbParameter("Einheit", System.Data.OleDb.OleDbType.VarChar, 0, "Einheit"),
            new System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.Integer, 0, "Intervall"),
            new System.Data.OleDb.OleDbParameter("Wochentage", System.Data.OleDb.OleDbType.Integer, 0, "Wochentage"),
            new System.Data.OleDb.OleDbParameter("BedarfsMedikationJN", System.Data.OleDb.OleDbType.Boolean, 0, "BedarfsMedikationJN"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("Herrichten", System.Data.OleDb.OleDbType.Integer, 0, "Herrichten"),
            new System.Data.OleDb.OleDbParameter("AerztlichevorbereitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "AerztlichevorbereitungJN"),
            new System.Data.OleDb.OleDbParameter("Verabreichungsart", System.Data.OleDb.OleDbType.Integer, 0, "Verabreichungsart"),
            new System.Data.OleDb.OleDbParameter("Applikationsform", System.Data.OleDb.OleDbType.VarChar, 0, "Applikationsform"),
            new System.Data.OleDb.OleDbParameter("Wiederholungstyp", System.Data.OleDb.OleDbType.Integer, 0, "Wiederholungstyp"),
            new System.Data.OleDb.OleDbParameter("Wiederholungseinheit", System.Data.OleDb.OleDbType.Integer, 0, "Wiederholungseinheit"),
            new System.Data.OleDb.OleDbParameter("Wiederholungswert", System.Data.OleDb.OleDbType.Double, 0, "Wiederholungswert"),
            new System.Data.OleDb.OleDbParameter("StandardzeitenJN", System.Data.OleDb.OleDbType.Boolean, 0, "StandardzeitenJN"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt0", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt0"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt1", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt1"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt2", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt2"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt3", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt3"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt4", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt4"),
            new System.Data.OleDb.OleDbParameter("Packunggroesse", System.Data.OleDb.OleDbType.Double, 0, "Packunggroesse"),
            new System.Data.OleDb.OleDbParameter("Rezeptdaten", System.Data.OleDb.OleDbType.VarChar, 0, "Rezeptdaten"),
            new System.Data.OleDb.OleDbParameter("Packungeinheit", System.Data.OleDb.OleDbType.VarChar, 0, "Packungeinheit"),
            new System.Data.OleDb.OleDbParameter("BestellenJN", System.Data.OleDb.OleDbType.Boolean, 0, "BestellenJN"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDAerzte", System.Data.OleDb.OleDbType.Guid, 0, "IDAerzte"),
            new System.Data.OleDb.OleDbParameter("AusstellungsDatum", System.Data.OleDb.OleDbType.Date, 16, "AusstellungsDatum"),
            new System.Data.OleDb.OleDbParameter("DosierungASString", System.Data.OleDb.OleDbType.VarChar, 0, "DosierungASString"),
            new System.Data.OleDb.OleDbParameter("Packungsanzahl", System.Data.OleDb.OleDbType.Integer, 0, "Packungsanzahl"),
            new System.Data.OleDb.OleDbParameter("ZuletztBestelltAm", System.Data.OleDb.OleDbType.Date, 16, "ZuletztBestelltAm"),
            new System.Data.OleDb.OleDbParameter("IDAerzteGeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDAerzteGeaendert"),
            new System.Data.OleDb.OleDbParameter("IDArztAbgesetzt", System.Data.OleDb.OleDbType.Guid, 0, "IDArztAbgesetzt"),
            new System.Data.OleDb.OleDbParameter("ZuletztBestelltVon", System.Data.OleDb.OleDbType.Guid, 0, "ZuletztBestelltVon"),
            new System.Data.OleDb.OleDbParameter("HAGPflichtigJN", System.Data.OleDb.OleDbType.Boolean, 0, "HAGPflichtigJN"),
            new System.Data.OleDb.OleDbParameter("lstMedDaten", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstMedDaten"),
            new System.Data.OleDb.OleDbParameter("ZeitpunktBlisterliste", System.Data.OleDb.OleDbType.Date, 16, "ZeitpunktBlisterliste"),
            new System.Data.OleDb.OleDbParameter("NumberMedDaten", System.Data.OleDb.OleDbType.Integer, 0, "NumberMedDaten"),
            new System.Data.OleDb.OleDbParameter("lstWunden", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstWunden"),
            new System.Data.OleDb.OleDbParameter("NumberWunden", System.Data.OleDb.OleDbType.Integer, 0, "NumberWunden"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [RezeptEintrag] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daRezeptEintrag
            // 
            this.daRezeptEintrag.DeleteCommand = this.oleDbDeleteCommand1;
            this.daRezeptEintrag.InsertCommand = this.oleDbInsertCommand1;
            this.daRezeptEintrag.SelectCommand = this.oleDbSelectCommand1;
            this.daRezeptEintrag.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "RezeptEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDMedikament", "IDMedikament"),
                        new System.Data.Common.DataColumnMapping("AbzugebenVon", "AbzugebenVon"),
                        new System.Data.Common.DataColumnMapping("AbzugebenBis", "AbzugebenBis"),
                        new System.Data.Common.DataColumnMapping("BeaufsichtigungJN", "BeaufsichtigungJN"),
                        new System.Data.Common.DataColumnMapping("ZP0", "ZP0"),
                        new System.Data.Common.DataColumnMapping("ZP1", "ZP1"),
                        new System.Data.Common.DataColumnMapping("ZP2", "ZP2"),
                        new System.Data.Common.DataColumnMapping("ZP3", "ZP3"),
                        new System.Data.Common.DataColumnMapping("ZP4", "ZP4"),
                        new System.Data.Common.DataColumnMapping("ZP5", "ZP5"),
                        new System.Data.Common.DataColumnMapping("ZP6", "ZP6"),
                        new System.Data.Common.DataColumnMapping("Einheit", "Einheit"),
                        new System.Data.Common.DataColumnMapping("Intervall", "Intervall"),
                        new System.Data.Common.DataColumnMapping("Wochentage", "Wochentage"),
                        new System.Data.Common.DataColumnMapping("BedarfsMedikationJN", "BedarfsMedikationJN"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("Herrichten", "Herrichten"),
                        new System.Data.Common.DataColumnMapping("AerztlichevorbereitungJN", "AerztlichevorbereitungJN"),
                        new System.Data.Common.DataColumnMapping("Verabreichungsart", "Verabreichungsart"),
                        new System.Data.Common.DataColumnMapping("Applikationsform", "Applikationsform"),
                        new System.Data.Common.DataColumnMapping("Wiederholungstyp", "Wiederholungstyp"),
                        new System.Data.Common.DataColumnMapping("Wiederholungseinheit", "Wiederholungseinheit"),
                        new System.Data.Common.DataColumnMapping("Wiederholungswert", "Wiederholungswert"),
                        new System.Data.Common.DataColumnMapping("StandardzeitenJN", "StandardzeitenJN"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt0", "Zeitpunkt0"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt1", "Zeitpunkt1"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt2", "Zeitpunkt2"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt3", "Zeitpunkt3"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt4", "Zeitpunkt4"),
                        new System.Data.Common.DataColumnMapping("Packunggroesse", "Packunggroesse"),
                        new System.Data.Common.DataColumnMapping("Rezeptdaten", "Rezeptdaten"),
                        new System.Data.Common.DataColumnMapping("Packungeinheit", "Packungeinheit"),
                        new System.Data.Common.DataColumnMapping("BestellenJN", "BestellenJN"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDAerzte", "IDAerzte"),
                        new System.Data.Common.DataColumnMapping("AusstellungsDatum", "AusstellungsDatum"),
                        new System.Data.Common.DataColumnMapping("DosierungASString", "DosierungASString"),
                        new System.Data.Common.DataColumnMapping("Packungsanzahl", "Packungsanzahl"),
                        new System.Data.Common.DataColumnMapping("ZuletztBestelltAm", "ZuletztBestelltAm"),
                        new System.Data.Common.DataColumnMapping("IDAerzteGeaendert", "IDAerzteGeaendert"),
                        new System.Data.Common.DataColumnMapping("IDArztAbgesetzt", "IDArztAbgesetzt"),
                        new System.Data.Common.DataColumnMapping("ZuletztBestelltVon", "ZuletztBestelltVon"),
                        new System.Data.Common.DataColumnMapping("HAGPflichtigJN", "HAGPflichtigJN"),
                        new System.Data.Common.DataColumnMapping("lstMedDaten", "lstMedDaten"),
                        new System.Data.Common.DataColumnMapping("ZeitpunktBlisterliste", "ZeitpunktBlisterliste"),
                        new System.Data.Common.DataColumnMapping("NumberMedDaten", "NumberMedDaten"),
                        new System.Data.Common.DataColumnMapping("lstWunden", "lstWunden"),
                        new System.Data.Common.DataColumnMapping("NumberWunden", "NumberWunden")})});
            this.daRezeptEintrag.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // dsRezeptEintrag1
            // 
            this.dsRezeptEintrag1.DataSetName = "dsRezeptEintrag";
            this.dsRezeptEintrag1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsRezeptEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenListeByMedikament1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRezeptEintrag1)).EndInit();

		}
		#endregion

		
        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert true wenn wein bestimmtes Medikament noch in benutzung ist/war
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool IsMedikamentInUse(Guid IDMedikament)
        {
            return PMDS.DB.DBUtil.MedikamentUsed(IDMedikament);
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen SubEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public void InitRow(dsRezeptEintrag.RezeptEintragRow r)
		{
            r.SetZeitpunkt0Null();
            r.SetZeitpunkt1Null();
            r.SetZeitpunkt2Null();
            r.SetZeitpunkt3Null();
            r.SetZeitpunkt4Null();
		}

		
        //----------------------------------------------------------------------------
        /// <summary>
        /// RezeptEintäge für Aufenthalt lesen
        /// </summary>
        //----------------------------------------------------------------------------
        public dsRezeptEintrag.RezeptEintragDataTable Read(Guid IDAufenthalt)
        {
            dsRezeptEintrag.RezeptEintragDataTable dt = new dsRezeptEintrag.RezeptEintragDataTable();
            daRezeptEintragByAufenthalt.SelectCommand.Parameters[0].Value = IDAufenthalt;
            DataBase.Fill(daRezeptEintragByAufenthalt, dt);
            return dt;
        }
        public bool ReadRezeptEintragbyID(Guid IDRezeptEintrag, ref dsRezeptEintrag ds)
        {
            this.daRezeptEintrag.SelectCommand.Parameters[0].Value = IDRezeptEintrag;
            DataBase.Fill(this.daRezeptEintrag, ds.RezeptEintrag);
            return true;
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Änderungen schreiben
        /// </summary>
        //----------------------------------------------------------------------------
        public void Update(dsRezeptEintrag.RezeptEintragDataTable dt)
        {
            DataBase.Update(daRezeptEintrag, dt);
        }



        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle Klienten die ein bestimmtes Medikament bekommen anzeigen. 
        /// Ausgenommen entlassene, geordnet nach Datum von
        /// </summary>
        //----------------------------------------------------------------------------
        public dsKlientenListeByMedikament.PatientDataTable KlientenListeByMedikament(Guid IDMedikament, Guid IDAufenthalt)
        {
            dsKlientenListeByMedikament ds = new dsKlientenListeByMedikament();
            daKlientenListeByMedikament.SelectCommand.Parameters[0].Value = IDMedikament;
            daKlientenListeByMedikament.SelectCommand.Parameters[2].Value = IDAufenthalt;
            daKlientenListeByMedikament.SelectCommand.Parameters[1].Value = DateTime.Now.AddMonths(-2);     // damit die alten Einträge nicht berücksichtigt werden
            
            DataBase.Fill(daKlientenListeByMedikament, ds.Patient);
            return ds.Patient;
        }
        
        
        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert alle Bedarfsmedikamente des Aufentahltes eines Klienten welche 
        /// zum angegebenen Tag gültig sind
        /// Textspalte: [Medikamentbezeichnung||Bemerkung zum Medikament]
        /// </summary> 
        //----------------------------------------------------------------------------
        public static dsGUIDListe.IDListeDataTable GetBedarfsMedikamente(Guid IDAufenthalt, DateTime Tag)
        {
            try
            {
                dsGUIDListe.IDListeDataTable dt = new dsGUIDListe.IDListeDataTable();

                //string sCommand = "SELECT DISTINCT IDMedikament, Medikament.Bezeichnung, RezeptEintrag.Bemerkung FROM RezeptEintrag INNER JOIN Medikament ON RezeptEintrag.IDMedikament = Medikament.ID WHERE (RezeptEintrag.IDAufenthalt = ?) AND (BedarfsMedikationJN = 1) and  (RezeptEintrag.AbzugebenVon <= ?) AND (RezeptEintrag.AbzugebenBis >= ?)";
                string sCommand = "SELECT DISTINCT RezeptEintrag.ID, Medikament.Bezeichnung, RezeptEintrag.Bemerkung, Rezepteintrag.Rezeptdaten, Rezepteintrag.DosierungAsString FROM RezeptEintrag INNER JOIN Medikament ON RezeptEintrag.IDMedikament = Medikament.ID WHERE (RezeptEintrag.IDAufenthalt = ?) AND (BedarfsMedikationJN = 1) and  (RezeptEintrag.AbzugebenVon <= ?) AND (RezeptEintrag.AbzugebenBis >= ?)";

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = sCommand;
                cmd.Parameters.AddWithValue("@ID", IDAufenthalt);

                OleDbParameter von = new OleDbParameter {ParameterName = "@von", OleDbType = OleDbType.Date, Value = Tag};
                cmd.Parameters.Add(von);

                OleDbParameter bis = new OleDbParameter {ParameterName = "@bis", OleDbType = OleDbType.Date, Value = Tag};
                cmd.Parameters.Add(bis);

                cmd.Connection = PMDS.Global.dbBase.getConn();
                using (DataTable dtSelect = new DataTable())
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.SelectCommand.CommandTimeout = 0;
                        da.Fill(dtSelect);
                        foreach (DataRow r in dtSelect.Rows)
                        {
                            if (ENV.UseEinzelverordnungMax24)
                            {
                                dt.AddIDListeRow(new Guid(r[0].ToString()), r[1].ToString().Replace("\r\n", " - ") + "||" + r[4].ToString() + "\n" + r[2].ToString());
                            }
                            else
                            {
                                if (ENV.MedikamenteImportType != "service")
                                {
                                    dt.AddIDListeRow(new Guid(r[0].ToString()), r[1].ToString().Replace("\r\n", " - ") + "||Hinweis: " + r[2].ToString() + "\n" + r[3].ToString());
                                }
                                else
                                {
                                    dt.AddIDListeRow(new Guid(r[0].ToString()), r[1].ToString().Replace("\r\n", " - ") + "||Hinweis: " + r[2].ToString());
                                }
                            }
                        }
                    }
                }
                return dt;
              }
            catch(Exception ex)
            {
                throw new Exception("GetBedarfsMedikamente: " + ex.ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Setzt für einen bestimmten RezeptEintrag das Bestelflag
        /// </summary> 
        //----------------------------------------------------------------------------
        public static void SetBestellFlagForEintrag(Guid IDRezeptEintrag, bool bBestellen)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Update Rezepteintrag set bestellenJN = ? where ID = ?";
            cmd.Parameters.AddWithValue("bJN", bBestellen);
            cmd.Parameters.AddWithValue("IDRezeptEintrag", IDRezeptEintrag);
            DataBase.EcecuteNonQuery(cmd);
        }
	}
}
