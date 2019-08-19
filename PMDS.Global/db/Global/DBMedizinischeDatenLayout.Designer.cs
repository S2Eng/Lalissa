namespace PMDS.DB.Global
{
    partial class DBMedizinischeDatenLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBMedizinischeDatenLayout));
            this.dsMedizinischeDatenLayout1 = new PMDS.Global.db.Global.dsMedizinischeDatenLayout();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daMedizinischeDatenLayout = new System.Data.OleDb.OleDbDataAdapter();
            this.daMedizinischeDatenLayoutByType = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsMedizinischeDatenLayout1)).BeginInit();
            // 
            // dsMedizinischeDatenLayout1
            // 
            this.dsMedizinischeDatenLayout1.DataSetName = "dsMedizinischeDatenLayout";
            this.dsMedizinischeDatenLayout1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT        ID, MedizinischerTyp, Bezeichnung, Beschreibung, Bemerkung, Beendig" +
    "ungsgrund, Therapie, Typ, bVisible\r\nFROM            MedizinischeDatenLayout\r\nORD" +
    "ER BY Bezeichnung";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Persist Security Info=True;Password=NiwQ" +
    "s21+!;User ID=hl;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [MedizinischeDatenLayout] ([ID], [MedizinischerTyp], [Bezeichnung], [" +
    "Beschreibung], [Bemerkung], [Beendigungsgrund], [Therapie], [Typ], [bVisible]) V" +
    "ALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("MedizinischerTyp", System.Data.OleDb.OleDbType.Integer, 0, "MedizinischerTyp"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.Integer, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.Integer, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("Beendigungsgrund", System.Data.OleDb.OleDbType.Integer, 0, "Beendigungsgrund"),
            new System.Data.OleDb.OleDbParameter("Therapie", System.Data.OleDb.OleDbType.Integer, 0, "Therapie"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.Integer, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("bVisible", System.Data.OleDb.OleDbType.Boolean, 0, "bVisible")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("MedizinischerTyp", System.Data.OleDb.OleDbType.Integer, 0, "MedizinischerTyp"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.Integer, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.Integer, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("Beendigungsgrund", System.Data.OleDb.OleDbType.Integer, 0, "Beendigungsgrund"),
            new System.Data.OleDb.OleDbParameter("Therapie", System.Data.OleDb.OleDbType.Integer, 0, "Therapie"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.Integer, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("bVisible", System.Data.OleDb.OleDbType.Boolean, 0, "bVisible"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [MedizinischeDatenLayout] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daMedizinischeDatenLayout
            // 
            this.daMedizinischeDatenLayout.DeleteCommand = this.oleDbDeleteCommand1;
            this.daMedizinischeDatenLayout.InsertCommand = this.oleDbInsertCommand1;
            this.daMedizinischeDatenLayout.SelectCommand = this.oleDbSelectCommand1;
            this.daMedizinischeDatenLayout.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "MedizinischeDatenLayout", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("MedizinischerTyp", "MedizinischerTyp"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("Beendigungsgrund", "Beendigungsgrund"),
                        new System.Data.Common.DataColumnMapping("Therapie", "Therapie"),
                        new System.Data.Common.DataColumnMapping("Typ", "Typ"),
                        new System.Data.Common.DataColumnMapping("bVisible", "bVisible")})});
            this.daMedizinischeDatenLayout.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // daMedizinischeDatenLayoutByType
            // 
            this.daMedizinischeDatenLayoutByType.SelectCommand = this.oleDbCommand3;
            this.daMedizinischeDatenLayoutByType.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "MedizinischeDatenLayout", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("MedizinischerTyp", "MedizinischerTyp"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("Beendigungsgrund", "Beendigungsgrund"),
                        new System.Data.Common.DataColumnMapping("Therapie", "Therapie"),
                        new System.Data.Common.DataColumnMapping("Typ", "Typ"),
                        new System.Data.Common.DataColumnMapping("bVisible", "bVisible")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("MedizinischerTyp", System.Data.OleDb.OleDbType.Integer, 4, "MedizinischerTyp")});
            ((System.ComponentModel.ISupportInitialize)(this.dsMedizinischeDatenLayout1)).EndInit();

        }

        #endregion

        private PMDS.Global.db.Global.dsMedizinischeDatenLayout dsMedizinischeDatenLayout1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daMedizinischeDatenLayout;
        private System.Data.OleDb.OleDbDataAdapter daMedizinischeDatenLayoutByType;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
    }
}
