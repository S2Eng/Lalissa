namespace PMDS.DB.Global
{
    partial class DBStandardProzeduren
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daStandardProzeduren = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daSPDynRep = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daEintragStandardprozeduren = new System.Data.OleDb.OleDbDataAdapter();
            this.dsStandardProzeduren1 = new PMDS.Data.Global.dsStandardProzeduren();
            ((System.ComponentModel.ISupportInitialize)(this.dsStandardProzeduren1)).BeginInit();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT        ID, Name, ShowPrintDialog, NotfallJN, Unterdrücken\r\nFROM           " +
    " StandardProzeduren\r\nORDER BY Name";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [StandardProzeduren] ([ID], [Name], [ShowPrintDialog], [NotfallJN], [" +
    "Unterdrücken]) VALUES (?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("ShowPrintDialog", System.Data.OleDb.OleDbType.Boolean, 0, "ShowPrintDialog"),
            new System.Data.OleDb.OleDbParameter("NotfallJN", System.Data.OleDb.OleDbType.Boolean, 0, "NotfallJN"),
            new System.Data.OleDb.OleDbParameter("Unterdrücken", System.Data.OleDb.OleDbType.Boolean, 0, "Unterdrücken")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [StandardProzeduren] SET [ID] = ?, [Name] = ?, [ShowPrintDialog] = ?, [Not" +
    "fallJN] = ?, [Unterdrücken] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("ShowPrintDialog", System.Data.OleDb.OleDbType.Boolean, 0, "ShowPrintDialog"),
            new System.Data.OleDb.OleDbParameter("NotfallJN", System.Data.OleDb.OleDbType.Boolean, 0, "NotfallJN"),
            new System.Data.OleDb.OleDbParameter("Unterdrücken", System.Data.OleDb.OleDbType.Boolean, 0, "Unterdrücken"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [StandardProzeduren] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daStandardProzeduren
            // 
            this.daStandardProzeduren.DeleteCommand = this.oleDbDeleteCommand1;
            this.daStandardProzeduren.InsertCommand = this.oleDbInsertCommand1;
            this.daStandardProzeduren.SelectCommand = this.oleDbSelectCommand1;
            this.daStandardProzeduren.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "StandardProzeduren", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("ShowPrintDialog", "ShowPrintDialog"),
                        new System.Data.Common.DataColumnMapping("NotfallJN", "NotfallJN"),
                        new System.Data.Common.DataColumnMapping("Unterdrücken", "Unterdrücken")})});
            this.daStandardProzeduren.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT     ID, IDStandardProzeduren, DynRep\r\nFROM         SPDynRep";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO [SPDynRep] ([ID], [IDStandardProzeduren], [DynRep]) VALUES (?, ?, ?)";
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDStandardProzeduren", System.Data.OleDb.OleDbType.Guid, 0, "IDStandardProzeduren"),
            new System.Data.OleDb.OleDbParameter("DynRep", System.Data.OleDb.OleDbType.VarChar, 0, "DynRep")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = "UPDATE [SPDynRep] SET [ID] = ?, [IDStandardProzeduren] = ?, [DynRep] = ? WHERE ((" +
    "[ID] = ?))";
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDStandardProzeduren", System.Data.OleDb.OleDbType.Guid, 0, "IDStandardProzeduren"),
            new System.Data.OleDb.OleDbParameter("DynRep", System.Data.OleDb.OleDbType.VarChar, 0, "DynRep"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM [SPDynRep] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daSPDynRep
            // 
            this.daSPDynRep.DeleteCommand = this.oleDbDeleteCommand2;
            this.daSPDynRep.InsertCommand = this.oleDbInsertCommand2;
            this.daSPDynRep.SelectCommand = this.oleDbSelectCommand2;
            this.daSPDynRep.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "SPDynRep", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDStandardProzeduren", "IDStandardProzeduren"),
                        new System.Data.Common.DataColumnMapping("DynRep", "DynRep")})});
            this.daSPDynRep.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT     ID, IDEintrag, IDStandardProzeduren, Reihenfolge\r\nFROM         Eintrag" +
    "Standardprozeduren";
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            // 
            // oleDbInsertCommand3
            // 
            this.oleDbInsertCommand3.CommandText = "INSERT INTO [EintragStandardprozeduren] ([ID], [IDEintrag], [IDStandardProzeduren" +
    "], [Reihenfolge]) VALUES (?, ?, ?, ?)";
            this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDStandardProzeduren", System.Data.OleDb.OleDbType.Guid, 0, "IDStandardProzeduren"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge")});
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = "UPDATE [EintragStandardprozeduren] SET [ID] = ?, [IDEintrag] = ?, [IDStandardProz" +
    "eduren] = ?, [Reihenfolge] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDStandardProzeduren", System.Data.OleDb.OleDbType.Guid, 0, "IDStandardProzeduren"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = "DELETE FROM [EintragStandardprozeduren] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daEintragStandardprozeduren
            // 
            this.daEintragStandardprozeduren.DeleteCommand = this.oleDbDeleteCommand3;
            this.daEintragStandardprozeduren.InsertCommand = this.oleDbInsertCommand3;
            this.daEintragStandardprozeduren.SelectCommand = this.oleDbSelectCommand3;
            this.daEintragStandardprozeduren.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "EintragStandardprozeduren", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDStandardProzeduren", "IDStandardProzeduren"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge")})});
            this.daEintragStandardprozeduren.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // dsStandardProzeduren1
            // 
            this.dsStandardProzeduren1.DataSetName = "dsStandardProzeduren";
            this.dsStandardProzeduren1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsStandardProzeduren1)).EndInit();

        }

        #endregion

        private PMDS.Data.Global.dsStandardProzeduren dsStandardProzeduren1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daStandardProzeduren;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        private System.Data.OleDb.OleDbDataAdapter daSPDynRep;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
        private System.Data.OleDb.OleDbDataAdapter daEintragStandardprozeduren;
    }
}
