using PMDS.Global.db.Global;

namespace PMDS.DB.Patient
{
    partial class DBPDXAnamnese
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPDXAnamnese));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPDXAnamnese = new System.Data.OleDb.OleDbDataAdapter();
            this.daPDXAnamneseByModell = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.dsIDTextBezeichnung1 = new dsIDTextBezeichnung();
            this.daAnamnesen = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.dsPDXAnamnese1 = new PMDS.Data.Patient.dsPDXAnamnese();
            ((System.ComponentModel.ISupportInitialize)(this.dsIDTextBezeichnung1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDXAnamnese1)).BeginInit();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            this.oleDbConnection1.InfoMessage += new System.Data.OleDb.OleDbInfoMessageEventHandler(this.oleDbConnection1_InfoMessage);
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.VarChar, 0, "Modell"),
            new System.Data.OleDb.OleDbParameter("Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, "Modellgruppe"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseKrohwinkel", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseKrohwinkel"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseOrem", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseOrem"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseNanda", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseNanda"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseRT", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseRT"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseJuchli", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseJuchli"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseRAI", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseRAI"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 0, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("Resourceklient", System.Data.OleDb.OleDbType.VarChar, 0, "Resourceklient"),
            new System.Data.OleDb.OleDbParameter("IDAnamnesePOP", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamnesePOP")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.VarChar, 0, "Modell"),
            new System.Data.OleDb.OleDbParameter("Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, "Modellgruppe"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseKrohwinkel", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseKrohwinkel"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseOrem", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseOrem"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseNanda", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseNanda"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseRT", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseRT"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseJuchli", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseJuchli"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseRAI", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseRAI"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 0, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("Resourceklient", System.Data.OleDb.OleDbType.VarChar, 0, "Resourceklient"),
            new System.Data.OleDb.OleDbParameter("IDAnamnesePOP", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamnesePOP"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Modell", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Modell", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Modell", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Modell", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Modellgruppe", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Modellgruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseKrohwinkel", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseKrohwinkel", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseKrohwinkel", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseKrohwinkel", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseOrem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseOrem", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseOrem", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseOrem", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseNanda", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseNanda", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseNanda", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseNanda", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseRT", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseRT", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseRT", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseRT", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseJuchli", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseJuchli", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseJuchli", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseJuchli", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseRAI", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseRAI", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseRAI", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseRAI", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDPDX", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDPDX", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPDX", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPDX", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Resourceklient", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Resourceklient", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Resourceklient", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Resourceklient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamnesePOP", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamnesePOP", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamnesePOP", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamnesePOP", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = resources.GetString("oleDbDeleteCommand1.CommandText");
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Modell", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Modell", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Modell", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Modell", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Modellgruppe", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Modellgruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseKrohwinkel", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseKrohwinkel", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseKrohwinkel", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseKrohwinkel", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseOrem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseOrem", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseOrem", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseOrem", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseNanda", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseNanda", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseNanda", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseNanda", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseRT", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseRT", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseRT", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseRT", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseJuchli", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseJuchli", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseJuchli", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseJuchli", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseRAI", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseRAI", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseRAI", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseRAI", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDPDX", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDPDX", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPDX", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPDX", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Resourceklient", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Resourceklient", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Resourceklient", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Resourceklient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamnesePOP", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamnesePOP", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamnesePOP", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamnesePOP", System.Data.DataRowVersion.Original, null)});
            // 
            // daPDXAnamnese
            // 
            this.daPDXAnamnese.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPDXAnamnese.InsertCommand = this.oleDbInsertCommand1;
            this.daPDXAnamnese.SelectCommand = this.oleDbSelectCommand1;
            this.daPDXAnamnese.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDXAnamnese", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Modell", "Modell"),
                        new System.Data.Common.DataColumnMapping("Modellgruppe", "Modellgruppe"),
                        new System.Data.Common.DataColumnMapping("IDAnamneseKrohwinkel", "IDAnamneseKrohwinkel"),
                        new System.Data.Common.DataColumnMapping("IDAnamneseOrem", "IDAnamneseOrem"),
                        new System.Data.Common.DataColumnMapping("IDAnamneseNanda", "IDAnamneseNanda"),
                        new System.Data.Common.DataColumnMapping("IDAnamneseRT", "IDAnamneseRT"),
                        new System.Data.Common.DataColumnMapping("IDAnamneseJuchli", "IDAnamneseJuchli"),
                        new System.Data.Common.DataColumnMapping("IDAnamneseRAI", "IDAnamneseRAI"),
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("Resourceklient", "Resourceklient"),
                        new System.Data.Common.DataColumnMapping("IDAnamnesePOP", "IDAnamnesePOP")})});
            this.daPDXAnamnese.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // daPDXAnamneseByModell
            // 
            this.daPDXAnamneseByModell.DeleteCommand = this.oleDbCommand1;
            this.daPDXAnamneseByModell.InsertCommand = this.oleDbCommand2;
            this.daPDXAnamneseByModell.SelectCommand = this.oleDbCommand3;
            this.daPDXAnamneseByModell.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDXAnamnese", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Modell", "Modell"),
                        new System.Data.Common.DataColumnMapping("Modellgruppe", "Modellgruppe"),
                        new System.Data.Common.DataColumnMapping("IDAnamneseKrohwinkel", "IDAnamneseKrohwinkel"),
                        new System.Data.Common.DataColumnMapping("IDAnamneseOrem", "IDAnamneseOrem"),
                        new System.Data.Common.DataColumnMapping("IDAnamneseNanda", "IDAnamneseNanda"),
                        new System.Data.Common.DataColumnMapping("IDAnamneseRT", "IDAnamneseRT"),
                        new System.Data.Common.DataColumnMapping("IDAnamneseJuchli", "IDAnamneseJuchli"),
                        new System.Data.Common.DataColumnMapping("IDAnamneseRAI", "IDAnamneseRAI"),
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("Resourceklient", "Resourceklient"),
                        new System.Data.Common.DataColumnMapping("IDAnamnesePOP", "IDAnamnesePOP")})});
            this.daPDXAnamneseByModell.UpdateCommand = this.oleDbCommand4;
            this.daPDXAnamneseByModell.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(this.daPDXAnamneseByModell_RowUpdated);
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Modell", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Modell", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Modell", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Modell", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Modellgruppe", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Modellgruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseKrohwinkel", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseKrohwinkel", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseKrohwinkel", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseKrohwinkel", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseOrem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseOrem", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseOrem", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseOrem", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseNanda", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseNanda", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseNanda", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseNanda", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseRT", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseRT", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseRT", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseRT", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseJuchli", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseJuchli", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseJuchli", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseJuchli", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseRAI", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseRAI", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseRAI", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseRAI", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDPDX", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDPDX", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPDX", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPDX", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Resourceklient", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Resourceklient", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Resourceklient", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Resourceklient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamnesePOP", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamnesePOP", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamnesePOP", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamnesePOP", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.VarChar, 0, "Modell"),
            new System.Data.OleDb.OleDbParameter("Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, "Modellgruppe"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseKrohwinkel", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseKrohwinkel"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseOrem", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseOrem"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseNanda", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseNanda"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseRT", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseRT"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseJuchli", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseJuchli"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseRAI", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseRAI"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 0, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("Resourceklient", System.Data.OleDb.OleDbType.VarChar, 0, "Resourceklient"),
            new System.Data.OleDb.OleDbParameter("IDAnamnesePOP", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamnesePOP")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.Char, 50, "Modell")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.VarChar, 0, "Modell"),
            new System.Data.OleDb.OleDbParameter("Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, "Modellgruppe"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseKrohwinkel", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseKrohwinkel"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseOrem", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseOrem"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseNanda", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseNanda"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseRT", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseRT"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseJuchli", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseJuchli"),
            new System.Data.OleDb.OleDbParameter("IDAnamneseRAI", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamneseRAI"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 0, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("Resourceklient", System.Data.OleDb.OleDbType.VarChar, 0, "Resourceklient"),
            new System.Data.OleDb.OleDbParameter("IDAnamnesePOP", System.Data.OleDb.OleDbType.Guid, 0, "IDAnamnesePOP"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Modell", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Modell", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Modell", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Modell", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Modellgruppe", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Modellgruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseKrohwinkel", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseKrohwinkel", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseKrohwinkel", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseKrohwinkel", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseOrem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseOrem", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseOrem", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseOrem", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseNanda", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseNanda", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseNanda", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseNanda", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseRT", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseRT", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseRT", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseRT", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseJuchli", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseJuchli", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseJuchli", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseJuchli", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamneseRAI", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamneseRAI", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamneseRAI", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamneseRAI", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDPDX", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDPDX", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPDX", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPDX", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Resourceklient", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Resourceklient", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Resourceklient", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Resourceklient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAnamnesePOP", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAnamnesePOP", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAnamnesePOP", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAnamnesePOP", System.Data.DataRowVersion.Original, null)});
            // 
            // dsIDTextBezeichnung1
            // 
            this.dsIDTextBezeichnung1.DataSetName = "dsIDTextBezeichnung";
            this.dsIDTextBezeichnung1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsIDTextBezeichnung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daAnamnesen
            // 
            this.daAnamnesen.SelectCommand = this.oleDbCommand7;
            this.daAnamnesen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Anamnese_Krohwinkel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT"),
                        new System.Data.Common.DataColumnMapping("BEZEICHNUNG", "BEZEICHNUNG")})});
            this.daAnamnesen.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(this.daAnamnesen_RowUpdated);
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = resources.GetString("oleDbCommand7.CommandText");
            this.oleDbCommand7.Connection = this.oleDbConnection1;
            this.oleDbCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Krohwinkel", System.Data.OleDb.OleDbType.Guid, 16),
            new System.Data.OleDb.OleDbParameter("Orem", System.Data.OleDb.OleDbType.Guid),
            new System.Data.OleDb.OleDbParameter("POP", System.Data.OleDb.OleDbType.Guid)});
            // 
            // dsPDXAnamnese1
            // 
            this.dsPDXAnamnese1.DataSetName = "dsPDXAnamnese";
            this.dsPDXAnamnese1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsIDTextBezeichnung1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDXAnamnese1)).EndInit();

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daPDXAnamnese;
        private PMDS.Data.Patient.dsPDXAnamnese dsPDXAnamnese1;
        private System.Data.OleDb.OleDbDataAdapter daPDXAnamneseByModell;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private dsIDTextBezeichnung dsIDTextBezeichnung1;
        private System.Data.OleDb.OleDbDataAdapter daAnamnesen;
        private System.Data.OleDb.OleDbCommand oleDbCommand7;
       
    }
}
