using PMDS.GUI.Klient;
namespace PMDS.Klient
{
    partial class DBMedizinischeDaten
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBMedizinischeDaten));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.dsMedizinischeDaten1 = new PMDS.GUI.Klient.dsMedizinischeDaten();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daMeDatenByPatient = new System.Data.OleDb.OleDbDataAdapter();
            this.daMedizinischeDatenByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsMedizinischeDaten1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // dsMedizinischeDaten1
            // 
            this.dsMedizinischeDaten1.DataSetName = "dsMedizinischeDaten";
            this.dsMedizinischeDaten1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDBenutzergeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzergeaendert"),
            new System.Data.OleDb.OleDbParameter("MedizinischerTyp", System.Data.OleDb.OleDbType.Integer, 0, "MedizinischerTyp"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("ICDCode", System.Data.OleDb.OleDbType.VarChar, 0, "ICDCode"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("Beendigungsgrund", System.Data.OleDb.OleDbType.VarChar, 0, "Beendigungsgrund"),
            new System.Data.OleDb.OleDbParameter("AufnahmediagnoseJN", System.Data.OleDb.OleDbType.Boolean, 0, "AufnahmediagnoseJN"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("Therapie", System.Data.OleDb.OleDbType.VarChar, 0, "Therapie"),
            new System.Data.OleDb.OleDbParameter("Anzahl", System.Data.OleDb.OleDbType.Double, 0, "Anzahl"),
            new System.Data.OleDb.OleDbParameter("NuechternJN", System.Data.OleDb.OleDbType.Boolean, 0, "NuechternJN"),
            new System.Data.OleDb.OleDbParameter("AntikoaguliertJN", System.Data.OleDb.OleDbType.Boolean, 0, "AntikoaguliertJN"),
            new System.Data.OleDb.OleDbParameter("Handling", System.Data.OleDb.OleDbType.VarChar, 0, "Handling"),
            new System.Data.OleDb.OleDbParameter("LetzteVersorgung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetzteVersorgung"),
            new System.Data.OleDb.OleDbParameter("NaechsteVersorgung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "NaechsteVersorgung"),
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.VarChar, 0, "Modell"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.VarChar, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("IDBefund", System.Data.OleDb.OleDbType.Guid, 0, "IDBefund"),
            new System.Data.OleDb.OleDbParameter("Groesse", System.Data.OleDb.OleDbType.VarChar, 0, "Groesse"),
            new System.Data.OleDb.OleDbParameter("Verordnungen", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Verordnungen"),
            new System.Data.OleDb.OleDbParameter("lstRezepteinträge", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstRezepteinträge"),
            new System.Data.OleDb.OleDbParameter("NumberRezepteinträge", System.Data.OleDb.OleDbType.Integer, 0, "NumberRezepteinträge")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDBenutzergeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzergeaendert"),
            new System.Data.OleDb.OleDbParameter("MedizinischerTyp", System.Data.OleDb.OleDbType.Integer, 0, "MedizinischerTyp"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("ICDCode", System.Data.OleDb.OleDbType.VarChar, 0, "ICDCode"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("Beendigungsgrund", System.Data.OleDb.OleDbType.VarChar, 0, "Beendigungsgrund"),
            new System.Data.OleDb.OleDbParameter("AufnahmediagnoseJN", System.Data.OleDb.OleDbType.Boolean, 0, "AufnahmediagnoseJN"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("Therapie", System.Data.OleDb.OleDbType.VarChar, 0, "Therapie"),
            new System.Data.OleDb.OleDbParameter("Anzahl", System.Data.OleDb.OleDbType.Double, 0, "Anzahl"),
            new System.Data.OleDb.OleDbParameter("NuechternJN", System.Data.OleDb.OleDbType.Boolean, 0, "NuechternJN"),
            new System.Data.OleDb.OleDbParameter("AntikoaguliertJN", System.Data.OleDb.OleDbType.Boolean, 0, "AntikoaguliertJN"),
            new System.Data.OleDb.OleDbParameter("Handling", System.Data.OleDb.OleDbType.VarChar, 0, "Handling"),
            new System.Data.OleDb.OleDbParameter("LetzteVersorgung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetzteVersorgung"),
            new System.Data.OleDb.OleDbParameter("NaechsteVersorgung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "NaechsteVersorgung"),
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.VarChar, 0, "Modell"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.VarChar, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("IDBefund", System.Data.OleDb.OleDbType.Guid, 0, "IDBefund"),
            new System.Data.OleDb.OleDbParameter("Groesse", System.Data.OleDb.OleDbType.VarChar, 0, "Groesse"),
            new System.Data.OleDb.OleDbParameter("Verordnungen", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Verordnungen"),
            new System.Data.OleDb.OleDbParameter("lstRezepteinträge", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstRezepteinträge"),
            new System.Data.OleDb.OleDbParameter("NumberRezepteinträge", System.Data.OleDb.OleDbType.Integer, 0, "NumberRezepteinträge"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [MedizinischeDaten] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daMeDatenByPatient
            // 
            this.daMeDatenByPatient.DeleteCommand = this.oleDbDeleteCommand1;
            this.daMeDatenByPatient.InsertCommand = this.oleDbInsertCommand1;
            this.daMeDatenByPatient.SelectCommand = this.oleDbSelectCommand1;
            this.daMeDatenByPatient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "MedizinischeDaten", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDBenutzergeaendert", "IDBenutzergeaendert"),
                        new System.Data.Common.DataColumnMapping("MedizinischerTyp", "MedizinischerTyp"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("ICDCode", "ICDCode"),
                        new System.Data.Common.DataColumnMapping("Von", "Von"),
                        new System.Data.Common.DataColumnMapping("Bis", "Bis"),
                        new System.Data.Common.DataColumnMapping("Beendigungsgrund", "Beendigungsgrund"),
                        new System.Data.Common.DataColumnMapping("AufnahmediagnoseJN", "AufnahmediagnoseJN"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("Therapie", "Therapie"),
                        new System.Data.Common.DataColumnMapping("Anzahl", "Anzahl"),
                        new System.Data.Common.DataColumnMapping("NuechternJN", "NuechternJN"),
                        new System.Data.Common.DataColumnMapping("AntikoaguliertJN", "AntikoaguliertJN"),
                        new System.Data.Common.DataColumnMapping("Handling", "Handling"),
                        new System.Data.Common.DataColumnMapping("LetzteVersorgung", "LetzteVersorgung"),
                        new System.Data.Common.DataColumnMapping("NaechsteVersorgung", "NaechsteVersorgung"),
                        new System.Data.Common.DataColumnMapping("Modell", "Modell"),
                        new System.Data.Common.DataColumnMapping("Typ", "Typ"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("Groesse", "Groesse"),
                        new System.Data.Common.DataColumnMapping("Verordnungen", "Verordnungen"),
                        new System.Data.Common.DataColumnMapping("lstRezepteinträge", "lstRezepteinträge"),
                        new System.Data.Common.DataColumnMapping("NumberRezepteinträge", "NumberRezepteinträge")})});
            this.daMeDatenByPatient.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // daMedizinischeDatenByID
            // 
            this.daMedizinischeDatenByID.DeleteCommand = this.oleDbCommand2;
            this.daMedizinischeDatenByID.InsertCommand = this.oleDbCommand3;
            this.daMedizinischeDatenByID.SelectCommand = this.oleDbCommand4;
            this.daMedizinischeDatenByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "MedizinischeDaten", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDBenutzergeaendert", "IDBenutzergeaendert"),
                        new System.Data.Common.DataColumnMapping("MedizinischerTyp", "MedizinischerTyp"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("ICDCode", "ICDCode"),
                        new System.Data.Common.DataColumnMapping("Von", "Von"),
                        new System.Data.Common.DataColumnMapping("Bis", "Bis"),
                        new System.Data.Common.DataColumnMapping("Beendigungsgrund", "Beendigungsgrund"),
                        new System.Data.Common.DataColumnMapping("AufnahmediagnoseJN", "AufnahmediagnoseJN"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("Therapie", "Therapie"),
                        new System.Data.Common.DataColumnMapping("Anzahl", "Anzahl"),
                        new System.Data.Common.DataColumnMapping("NuechternJN", "NuechternJN"),
                        new System.Data.Common.DataColumnMapping("AntikoaguliertJN", "AntikoaguliertJN"),
                        new System.Data.Common.DataColumnMapping("Handling", "Handling"),
                        new System.Data.Common.DataColumnMapping("LetzteVersorgung", "LetzteVersorgung"),
                        new System.Data.Common.DataColumnMapping("NaechsteVersorgung", "NaechsteVersorgung"),
                        new System.Data.Common.DataColumnMapping("Modell", "Modell"),
                        new System.Data.Common.DataColumnMapping("Groesse", "Groesse"),
                        new System.Data.Common.DataColumnMapping("Typ", "Typ"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("Verordnungen", "Verordnungen"),
                        new System.Data.Common.DataColumnMapping("lstRezepteinträge", "lstRezepteinträge"),
                        new System.Data.Common.DataColumnMapping("NumberRezepteinträge", "NumberRezepteinträge")})});
            this.daMedizinischeDatenByID.UpdateCommand = this.oleDbCommand5;
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "DELETE FROM [MedizinischeDaten] WHERE (([ID] = ?))";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDBenutzergeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzergeaendert"),
            new System.Data.OleDb.OleDbParameter("MedizinischerTyp", System.Data.OleDb.OleDbType.Integer, 0, "MedizinischerTyp"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("ICDCode", System.Data.OleDb.OleDbType.VarChar, 0, "ICDCode"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("Beendigungsgrund", System.Data.OleDb.OleDbType.VarChar, 0, "Beendigungsgrund"),
            new System.Data.OleDb.OleDbParameter("AufnahmediagnoseJN", System.Data.OleDb.OleDbType.Boolean, 0, "AufnahmediagnoseJN"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("Therapie", System.Data.OleDb.OleDbType.VarChar, 0, "Therapie"),
            new System.Data.OleDb.OleDbParameter("Anzahl", System.Data.OleDb.OleDbType.Double, 0, "Anzahl"),
            new System.Data.OleDb.OleDbParameter("NuechternJN", System.Data.OleDb.OleDbType.Boolean, 0, "NuechternJN"),
            new System.Data.OleDb.OleDbParameter("AntikoaguliertJN", System.Data.OleDb.OleDbType.Boolean, 0, "AntikoaguliertJN"),
            new System.Data.OleDb.OleDbParameter("Handling", System.Data.OleDb.OleDbType.VarChar, 0, "Handling"),
            new System.Data.OleDb.OleDbParameter("LetzteVersorgung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetzteVersorgung"),
            new System.Data.OleDb.OleDbParameter("NaechsteVersorgung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "NaechsteVersorgung"),
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.VarChar, 0, "Modell"),
            new System.Data.OleDb.OleDbParameter("Groesse", System.Data.OleDb.OleDbType.VarChar, 0, "Groesse"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.VarChar, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("IDBefund", System.Data.OleDb.OleDbType.Guid, 0, "IDBefund"),
            new System.Data.OleDb.OleDbParameter("Verordnungen", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Verordnungen"),
            new System.Data.OleDb.OleDbParameter("lstRezepteinträge", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstRezepteinträge"),
            new System.Data.OleDb.OleDbParameter("NumberRezepteinträge", System.Data.OleDb.OleDbType.Integer, 0, "NumberRezepteinträge")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = resources.GetString("oleDbCommand5.CommandText");
            this.oleDbCommand5.Connection = this.oleDbConnection1;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDBenutzergeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzergeaendert"),
            new System.Data.OleDb.OleDbParameter("MedizinischerTyp", System.Data.OleDb.OleDbType.Integer, 0, "MedizinischerTyp"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("ICDCode", System.Data.OleDb.OleDbType.VarChar, 0, "ICDCode"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("Beendigungsgrund", System.Data.OleDb.OleDbType.VarChar, 0, "Beendigungsgrund"),
            new System.Data.OleDb.OleDbParameter("AufnahmediagnoseJN", System.Data.OleDb.OleDbType.Boolean, 0, "AufnahmediagnoseJN"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("Therapie", System.Data.OleDb.OleDbType.VarChar, 0, "Therapie"),
            new System.Data.OleDb.OleDbParameter("Anzahl", System.Data.OleDb.OleDbType.Double, 0, "Anzahl"),
            new System.Data.OleDb.OleDbParameter("NuechternJN", System.Data.OleDb.OleDbType.Boolean, 0, "NuechternJN"),
            new System.Data.OleDb.OleDbParameter("AntikoaguliertJN", System.Data.OleDb.OleDbType.Boolean, 0, "AntikoaguliertJN"),
            new System.Data.OleDb.OleDbParameter("Handling", System.Data.OleDb.OleDbType.VarChar, 0, "Handling"),
            new System.Data.OleDb.OleDbParameter("LetzteVersorgung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetzteVersorgung"),
            new System.Data.OleDb.OleDbParameter("NaechsteVersorgung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "NaechsteVersorgung"),
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.VarChar, 0, "Modell"),
            new System.Data.OleDb.OleDbParameter("Groesse", System.Data.OleDb.OleDbType.VarChar, 0, "Groesse"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.VarChar, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("IDBefund", System.Data.OleDb.OleDbType.Guid, 0, "IDBefund"),
            new System.Data.OleDb.OleDbParameter("Verordnungen", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Verordnungen"),
            new System.Data.OleDb.OleDbParameter("lstRezepteinträge", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstRezepteinträge"),
            new System.Data.OleDb.OleDbParameter("NumberRezepteinträge", System.Data.OleDb.OleDbType.Integer, 0, "NumberRezepteinträge"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsMedizinischeDaten1)).EndInit();

        }

        #endregion

        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private dsMedizinischeDaten dsMedizinischeDaten1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daMeDatenByPatient;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private System.Data.OleDb.OleDbCommand oleDbCommand5;
        public System.Data.OleDb.OleDbDataAdapter daMedizinischeDatenByID;
    }
}
