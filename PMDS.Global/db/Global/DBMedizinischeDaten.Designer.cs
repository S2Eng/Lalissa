namespace PMDS.DB.Global
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
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daMedizinischeDaten = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daAllOpen = new System.Data.OleDb.OleDbDataAdapter();
            this.daAllOpenRam = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
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
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.Date, 16, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.Date, 16, "Bis"),
            new System.Data.OleDb.OleDbParameter("Beendigungsgrund", System.Data.OleDb.OleDbType.VarChar, 0, "Beendigungsgrund"),
            new System.Data.OleDb.OleDbParameter("AufnahmediagnoseJN", System.Data.OleDb.OleDbType.Boolean, 0, "AufnahmediagnoseJN"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("Therapie", System.Data.OleDb.OleDbType.VarChar, 0, "Therapie"),
            new System.Data.OleDb.OleDbParameter("Anzahl", System.Data.OleDb.OleDbType.Double, 0, "Anzahl"),
            new System.Data.OleDb.OleDbParameter("NuechternJN", System.Data.OleDb.OleDbType.Boolean, 0, "NuechternJN"),
            new System.Data.OleDb.OleDbParameter("AntikoaguliertJN", System.Data.OleDb.OleDbType.Boolean, 0, "AntikoaguliertJN"),
            new System.Data.OleDb.OleDbParameter("Handling", System.Data.OleDb.OleDbType.VarChar, 0, "Handling"),
            new System.Data.OleDb.OleDbParameter("LetzteVersorgung", System.Data.OleDb.OleDbType.Date, 16, "LetzteVersorgung"),
            new System.Data.OleDb.OleDbParameter("NaechsteVersorgung", System.Data.OleDb.OleDbType.Date, 16, "NaechsteVersorgung"),
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.VarChar, 0, "Modell"),
            new System.Data.OleDb.OleDbParameter("Groesse", System.Data.OleDb.OleDbType.VarChar, 0, "Groesse"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.VarChar, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("IDBefund", System.Data.OleDb.OleDbType.Guid, 0, "IDBefund"),
            new System.Data.OleDb.OleDbParameter("Verordnungen", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Verordnungen"),
            new System.Data.OleDb.OleDbParameter("lstRezepteinträge", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstRezepteinträge")});
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
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.Date, 16, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.Date, 16, "Bis"),
            new System.Data.OleDb.OleDbParameter("Beendigungsgrund", System.Data.OleDb.OleDbType.VarChar, 0, "Beendigungsgrund"),
            new System.Data.OleDb.OleDbParameter("AufnahmediagnoseJN", System.Data.OleDb.OleDbType.Boolean, 0, "AufnahmediagnoseJN"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("Therapie", System.Data.OleDb.OleDbType.VarChar, 0, "Therapie"),
            new System.Data.OleDb.OleDbParameter("Anzahl", System.Data.OleDb.OleDbType.Double, 0, "Anzahl"),
            new System.Data.OleDb.OleDbParameter("NuechternJN", System.Data.OleDb.OleDbType.Boolean, 0, "NuechternJN"),
            new System.Data.OleDb.OleDbParameter("AntikoaguliertJN", System.Data.OleDb.OleDbType.Boolean, 0, "AntikoaguliertJN"),
            new System.Data.OleDb.OleDbParameter("Handling", System.Data.OleDb.OleDbType.VarChar, 0, "Handling"),
            new System.Data.OleDb.OleDbParameter("LetzteVersorgung", System.Data.OleDb.OleDbType.Date, 16, "LetzteVersorgung"),
            new System.Data.OleDb.OleDbParameter("NaechsteVersorgung", System.Data.OleDb.OleDbType.Date, 16, "NaechsteVersorgung"),
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.VarChar, 0, "Modell"),
            new System.Data.OleDb.OleDbParameter("Groesse", System.Data.OleDb.OleDbType.VarChar, 0, "Groesse"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.VarChar, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("IDBefund", System.Data.OleDb.OleDbType.Guid, 0, "IDBefund"),
            new System.Data.OleDb.OleDbParameter("Verordnungen", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Verordnungen"),
            new System.Data.OleDb.OleDbParameter("lstRezepteinträge", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstRezepteinträge"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [MedizinischeDaten] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daMedizinischeDaten
            // 
            this.daMedizinischeDaten.DeleteCommand = this.oleDbDeleteCommand1;
            this.daMedizinischeDaten.InsertCommand = this.oleDbInsertCommand1;
            this.daMedizinischeDaten.SelectCommand = this.oleDbSelectCommand1;
            this.daMedizinischeDaten.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
                        new System.Data.Common.DataColumnMapping("lstRezepteinträge", "lstRezepteinträge")})});
            this.daMedizinischeDaten.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("MedizinischerTyp", System.Data.OleDb.OleDbType.Integer, 4, "MedizinischerTyp")});
            // 
            // daAllOpen
            // 
            this.daAllOpen.SelectCommand = this.oleDbSelectCommand2;
            this.daAllOpen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
                        new System.Data.Common.DataColumnMapping("lstRezepteinträge", "lstRezepteinträge")})});
            // 
            // daAllOpenRam
            // 
            this.daAllOpenRam.SelectCommand = this.oleDbCommand1;
            this.daAllOpenRam.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
                        new System.Data.Common.DataColumnMapping("lstRezepteinträge", "lstRezepteinträge")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.oleDbConnection1;

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daMedizinischeDaten;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private System.Data.OleDb.OleDbDataAdapter daAllOpen;
        private System.Data.OleDb.OleDbDataAdapter daAllOpenRam;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
    }
}
