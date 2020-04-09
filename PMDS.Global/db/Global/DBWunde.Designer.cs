namespace PMDS.DB.Global
{
    partial class DBWunde
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
            System.Data.OleDb.OleDbConnection oleDbConnection1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBWunde));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daWundeKopf = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daWundePos = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daWundePosBilder = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
            this.daWundeTherapie = new System.Data.OleDb.OleDbDataAdapter();
            this.daWundePosAllThumbs = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daWundeTherapieByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.daWundePosByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            // 
            // oleDbConnection1
            // 
            oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Integrated Security=SSPI;Initial Catalog" +
    "=PMDSDev";
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthaltPDx", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthaltPDx")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthaltPDx", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthaltPDx"),
            new System.Data.OleDb.OleDbParameter("Wundart", System.Data.OleDb.OleDbType.VarChar, 0, "Wundart"),
            new System.Data.OleDb.OleDbParameter("Dekuskala", System.Data.OleDb.OleDbType.VarChar, 0, "Dekuskala"),
            new System.Data.OleDb.OleDbParameter("Dekuwert", System.Data.OleDb.OleDbType.Integer, 0, "Dekuwert"),
            new System.Data.OleDb.OleDbParameter("ClickedImage", System.Data.OleDb.OleDbType.LongVarBinary, 0, "ClickedImage"),
            new System.Data.OleDb.OleDbParameter("ClickedValueX", System.Data.OleDb.OleDbType.Integer, 0, "ClickedValueX"),
            new System.Data.OleDb.OleDbParameter("ClickedValueY", System.Data.OleDb.OleDbType.Integer, 0, "ClickedValueY"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("BekanntSeit", System.Data.OleDb.OleDbType.Date, 16, "BekanntSeit"),
            new System.Data.OleDb.OleDbParameter("BisherigeBehandlung", System.Data.OleDb.OleDbType.VarChar, 0, "BisherigeBehandlung"),
            new System.Data.OleDb.OleDbParameter("WundeEntstanden", System.Data.OleDb.OleDbType.VarChar, 0, "WundeEntstanden")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthaltPDx", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthaltPDx"),
            new System.Data.OleDb.OleDbParameter("Wundart", System.Data.OleDb.OleDbType.VarChar, 0, "Wundart"),
            new System.Data.OleDb.OleDbParameter("Dekuskala", System.Data.OleDb.OleDbType.VarChar, 0, "Dekuskala"),
            new System.Data.OleDb.OleDbParameter("Dekuwert", System.Data.OleDb.OleDbType.Integer, 0, "Dekuwert"),
            new System.Data.OleDb.OleDbParameter("ClickedImage", System.Data.OleDb.OleDbType.LongVarBinary, 0, "ClickedImage"),
            new System.Data.OleDb.OleDbParameter("ClickedValueX", System.Data.OleDb.OleDbType.Integer, 0, "ClickedValueX"),
            new System.Data.OleDb.OleDbParameter("ClickedValueY", System.Data.OleDb.OleDbType.Integer, 0, "ClickedValueY"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("BekanntSeit", System.Data.OleDb.OleDbType.Date, 16, "BekanntSeit"),
            new System.Data.OleDb.OleDbParameter("BisherigeBehandlung", System.Data.OleDb.OleDbType.VarChar, 0, "BisherigeBehandlung"),
            new System.Data.OleDb.OleDbParameter("WundeEntstanden", System.Data.OleDb.OleDbType.VarChar, 0, "WundeEntstanden"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [WundeKopf] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daWundeKopf
            // 
            this.daWundeKopf.DeleteCommand = this.oleDbDeleteCommand1;
            this.daWundeKopf.InsertCommand = this.oleDbInsertCommand1;
            this.daWundeKopf.SelectCommand = this.oleDbSelectCommand1;
            this.daWundeKopf.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "WundeKopf", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthaltPDx", "IDAufenthaltPDx"),
                        new System.Data.Common.DataColumnMapping("Wundart", "Wundart"),
                        new System.Data.Common.DataColumnMapping("Dekuskala", "Dekuskala"),
                        new System.Data.Common.DataColumnMapping("Dekuwert", "Dekuwert"),
                        new System.Data.Common.DataColumnMapping("ClickedImage", "ClickedImage"),
                        new System.Data.Common.DataColumnMapping("ClickedValueX", "ClickedValueX"),
                        new System.Data.Common.DataColumnMapping("ClickedValueY", "ClickedValueY"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("BekanntSeit", "BekanntSeit"),
                        new System.Data.Common.DataColumnMapping("BisherigeBehandlung", "BisherigeBehandlung"),
                        new System.Data.Common.DataColumnMapping("WundeEntstanden", "WundeEntstanden")})});
            this.daWundeKopf.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDWundeKopf", System.Data.OleDb.OleDbType.Guid, 16, "IDWundeKopf")});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = resources.GetString("oleDbInsertCommand2.CommandText");
            this.oleDbInsertCommand2.Connection = oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDWundeKopf", System.Data.OleDb.OleDbType.Guid, 0, "IDWundeKopf"),
            new System.Data.OleDb.OleDbParameter("Erhebungszeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "Erhebungszeitpunkt"),
            new System.Data.OleDb.OleDbParameter("Stadium", System.Data.OleDb.OleDbType.Integer, 0, "Stadium"),
            new System.Data.OleDb.OleDbParameter("Schmerzqualitaet", System.Data.OleDb.OleDbType.VarChar, 0, "Schmerzqualitaet"),
            new System.Data.OleDb.OleDbParameter("Schmerzintensitaet", System.Data.OleDb.OleDbType.Integer, 0, "Schmerzintensitaet"),
            new System.Data.OleDb.OleDbParameter("NekroseJN", System.Data.OleDb.OleDbType.Boolean, 0, "NekroseJN"),
            new System.Data.OleDb.OleDbParameter("Wundzustand", System.Data.OleDb.OleDbType.VarChar, 0, "Wundzustand"),
            new System.Data.OleDb.OleDbParameter("L", System.Data.OleDb.OleDbType.Double, 0, "L"),
            new System.Data.OleDb.OleDbParameter("B", System.Data.OleDb.OleDbType.Double, 0, "B"),
            new System.Data.OleDb.OleDbParameter("H", System.Data.OleDb.OleDbType.Double, 0, "H"),
            new System.Data.OleDb.OleDbParameter("Erreger", System.Data.OleDb.OleDbType.VarChar, 0, "Erreger"),
            new System.Data.OleDb.OleDbParameter("Infektionszeichen", System.Data.OleDb.OleDbType.VarChar, 0, "Infektionszeichen"),
            new System.Data.OleDb.OleDbParameter("Heilungsverlauf", System.Data.OleDb.OleDbType.Integer, 0, "Heilungsverlauf"),
            new System.Data.OleDb.OleDbParameter("Heilungstext", System.Data.OleDb.OleDbType.VarChar, 0, "Heilungstext"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("GranulationProz", System.Data.OleDb.OleDbType.Integer, 0, "GranulationProz"),
            new System.Data.OleDb.OleDbParameter("EpithelisierungProz", System.Data.OleDb.OleDbType.Integer, 0, "EpithelisierungProz"),
            new System.Data.OleDb.OleDbParameter("FistelnTaschen", System.Data.OleDb.OleDbType.VarChar, 0, "FistelnTaschen"),
            new System.Data.OleDb.OleDbParameter("Wundbelag", System.Data.OleDb.OleDbType.VarChar, 0, "Wundbelag"),
            new System.Data.OleDb.OleDbParameter("WundeFreiliegendeStrukturen", System.Data.OleDb.OleDbType.VarChar, 0, "WundeFreiliegendeStrukturen"),
            new System.Data.OleDb.OleDbParameter("Wundsekretion", System.Data.OleDb.OleDbType.VarChar, 0, "Wundsekretion"),
            new System.Data.OleDb.OleDbParameter("Sekretionsmenge", System.Data.OleDb.OleDbType.VarChar, 0, "Sekretionsmenge"),
            new System.Data.OleDb.OleDbParameter("Wundgeruch", System.Data.OleDb.OleDbType.VarChar, 0, "Wundgeruch"),
            new System.Data.OleDb.OleDbParameter("WundrandIntakt", System.Data.OleDb.OleDbType.Boolean, 0, "WundrandIntakt"),
            new System.Data.OleDb.OleDbParameter("WundrandMazeriert", System.Data.OleDb.OleDbType.Boolean, 0, "WundrandMazeriert"),
            new System.Data.OleDb.OleDbParameter("WundrandUnterminiertZerklueftet", System.Data.OleDb.OleDbType.VarChar, 0, "WundrandUnterminiertZerklueftet"),
            new System.Data.OleDb.OleDbParameter("WundrandGeroetet", System.Data.OleDb.OleDbType.Boolean, 0, "WundrandGeroetet"),
            new System.Data.OleDb.OleDbParameter("WundrandHyperkeratose", System.Data.OleDb.OleDbType.Boolean, 0, "WundrandHyperkeratose"),
            new System.Data.OleDb.OleDbParameter("WundumgebungIntakt", System.Data.OleDb.OleDbType.Boolean, 0, "WundumgebungIntakt"),
            new System.Data.OleDb.OleDbParameter("WundumgebungTrockenPergamentartig", System.Data.OleDb.OleDbType.VarChar, 0, "WundumgebungTrockenPergamentartig"),
            new System.Data.OleDb.OleDbParameter("WundumgebungEkzemOedemRoetung", System.Data.OleDb.OleDbType.VarChar, 0, "WundumgebungEkzemOedemRoetung"),
            new System.Data.OleDb.OleDbParameter("WundumgebungSpannungsblase", System.Data.OleDb.OleDbType.Boolean, 0, "WundumgebungSpannungsblase"),
            new System.Data.OleDb.OleDbParameter("Wundumgebung", System.Data.OleDb.OleDbType.VarChar, 0, "Wundumgebung"),
            new System.Data.OleDb.OleDbParameter("WundrandOedemoesWulstig", System.Data.OleDb.OleDbType.VarChar, 0, "WundrandOedemoesWulstig"),
            new System.Data.OleDb.OleDbParameter("Wundheilungsphase", System.Data.OleDb.OleDbType.VarChar, 0, "Wundheilungsphase"),
            new System.Data.OleDb.OleDbParameter("Wundgrund", System.Data.OleDb.OleDbType.VarChar, 0, "Wundgrund")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDWundeKopf", System.Data.OleDb.OleDbType.Guid, 0, "IDWundeKopf"),
            new System.Data.OleDb.OleDbParameter("Erhebungszeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "Erhebungszeitpunkt"),
            new System.Data.OleDb.OleDbParameter("Stadium", System.Data.OleDb.OleDbType.Integer, 0, "Stadium"),
            new System.Data.OleDb.OleDbParameter("Schmerzqualitaet", System.Data.OleDb.OleDbType.VarChar, 0, "Schmerzqualitaet"),
            new System.Data.OleDb.OleDbParameter("Schmerzintensitaet", System.Data.OleDb.OleDbType.Integer, 0, "Schmerzintensitaet"),
            new System.Data.OleDb.OleDbParameter("NekroseJN", System.Data.OleDb.OleDbType.Boolean, 0, "NekroseJN"),
            new System.Data.OleDb.OleDbParameter("Wundzustand", System.Data.OleDb.OleDbType.VarChar, 0, "Wundzustand"),
            new System.Data.OleDb.OleDbParameter("L", System.Data.OleDb.OleDbType.Double, 0, "L"),
            new System.Data.OleDb.OleDbParameter("B", System.Data.OleDb.OleDbType.Double, 0, "B"),
            new System.Data.OleDb.OleDbParameter("H", System.Data.OleDb.OleDbType.Double, 0, "H"),
            new System.Data.OleDb.OleDbParameter("Erreger", System.Data.OleDb.OleDbType.VarChar, 0, "Erreger"),
            new System.Data.OleDb.OleDbParameter("Infektionszeichen", System.Data.OleDb.OleDbType.VarChar, 0, "Infektionszeichen"),
            new System.Data.OleDb.OleDbParameter("Heilungsverlauf", System.Data.OleDb.OleDbType.Integer, 0, "Heilungsverlauf"),
            new System.Data.OleDb.OleDbParameter("Heilungstext", System.Data.OleDb.OleDbType.VarChar, 0, "Heilungstext"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("GranulationProz", System.Data.OleDb.OleDbType.Integer, 0, "GranulationProz"),
            new System.Data.OleDb.OleDbParameter("EpithelisierungProz", System.Data.OleDb.OleDbType.Integer, 0, "EpithelisierungProz"),
            new System.Data.OleDb.OleDbParameter("FistelnTaschen", System.Data.OleDb.OleDbType.VarChar, 0, "FistelnTaschen"),
            new System.Data.OleDb.OleDbParameter("Wundbelag", System.Data.OleDb.OleDbType.VarChar, 0, "Wundbelag"),
            new System.Data.OleDb.OleDbParameter("WundeFreiliegendeStrukturen", System.Data.OleDb.OleDbType.VarChar, 0, "WundeFreiliegendeStrukturen"),
            new System.Data.OleDb.OleDbParameter("Wundsekretion", System.Data.OleDb.OleDbType.VarChar, 0, "Wundsekretion"),
            new System.Data.OleDb.OleDbParameter("Sekretionsmenge", System.Data.OleDb.OleDbType.VarChar, 0, "Sekretionsmenge"),
            new System.Data.OleDb.OleDbParameter("Wundgeruch", System.Data.OleDb.OleDbType.VarChar, 0, "Wundgeruch"),
            new System.Data.OleDb.OleDbParameter("WundrandIntakt", System.Data.OleDb.OleDbType.Boolean, 0, "WundrandIntakt"),
            new System.Data.OleDb.OleDbParameter("WundrandMazeriert", System.Data.OleDb.OleDbType.Boolean, 0, "WundrandMazeriert"),
            new System.Data.OleDb.OleDbParameter("WundrandUnterminiertZerklueftet", System.Data.OleDb.OleDbType.VarChar, 0, "WundrandUnterminiertZerklueftet"),
            new System.Data.OleDb.OleDbParameter("WundrandGeroetet", System.Data.OleDb.OleDbType.Boolean, 0, "WundrandGeroetet"),
            new System.Data.OleDb.OleDbParameter("WundrandHyperkeratose", System.Data.OleDb.OleDbType.Boolean, 0, "WundrandHyperkeratose"),
            new System.Data.OleDb.OleDbParameter("WundumgebungIntakt", System.Data.OleDb.OleDbType.Boolean, 0, "WundumgebungIntakt"),
            new System.Data.OleDb.OleDbParameter("WundumgebungTrockenPergamentartig", System.Data.OleDb.OleDbType.VarChar, 0, "WundumgebungTrockenPergamentartig"),
            new System.Data.OleDb.OleDbParameter("WundumgebungEkzemOedemRoetung", System.Data.OleDb.OleDbType.VarChar, 0, "WundumgebungEkzemOedemRoetung"),
            new System.Data.OleDb.OleDbParameter("WundumgebungSpannungsblase", System.Data.OleDb.OleDbType.Boolean, 0, "WundumgebungSpannungsblase"),
            new System.Data.OleDb.OleDbParameter("Wundumgebung", System.Data.OleDb.OleDbType.VarChar, 0, "Wundumgebung"),
            new System.Data.OleDb.OleDbParameter("WundrandOedemoesWulstig", System.Data.OleDb.OleDbType.VarChar, 0, "WundrandOedemoesWulstig"),
            new System.Data.OleDb.OleDbParameter("Wundheilungsphase", System.Data.OleDb.OleDbType.VarChar, 0, "Wundheilungsphase"),
            new System.Data.OleDb.OleDbParameter("Wundgrund", System.Data.OleDb.OleDbType.VarChar, 0, "Wundgrund"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM [WundePos] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand2.Connection = oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daWundePos
            // 
            this.daWundePos.DeleteCommand = this.oleDbDeleteCommand2;
            this.daWundePos.InsertCommand = this.oleDbInsertCommand2;
            this.daWundePos.SelectCommand = this.oleDbSelectCommand2;
            this.daWundePos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "WundePos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDWundeKopf", "IDWundeKopf"),
                        new System.Data.Common.DataColumnMapping("Erhebungszeitpunkt", "Erhebungszeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Stadium", "Stadium"),
                        new System.Data.Common.DataColumnMapping("Schmerzqualitaet", "Schmerzqualitaet"),
                        new System.Data.Common.DataColumnMapping("Schmerzintensitaet", "Schmerzintensitaet"),
                        new System.Data.Common.DataColumnMapping("NekroseJN", "NekroseJN"),
                        new System.Data.Common.DataColumnMapping("Wundzustand", "Wundzustand"),
                        new System.Data.Common.DataColumnMapping("L", "L"),
                        new System.Data.Common.DataColumnMapping("B", "B"),
                        new System.Data.Common.DataColumnMapping("H", "H"),
                        new System.Data.Common.DataColumnMapping("Erreger", "Erreger"),
                        new System.Data.Common.DataColumnMapping("Infektionszeichen", "Infektionszeichen"),
                        new System.Data.Common.DataColumnMapping("Heilungsverlauf", "Heilungsverlauf"),
                        new System.Data.Common.DataColumnMapping("Heilungstext", "Heilungstext"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("GranulationProz", "GranulationProz"),
                        new System.Data.Common.DataColumnMapping("EpithelisierungProz", "EpithelisierungProz"),
                        new System.Data.Common.DataColumnMapping("FistelnTaschen", "FistelnTaschen"),
                        new System.Data.Common.DataColumnMapping("Wundbelag", "Wundbelag"),
                        new System.Data.Common.DataColumnMapping("WundeFreiliegendeStrukturen", "WundeFreiliegendeStrukturen"),
                        new System.Data.Common.DataColumnMapping("Wundsekretion", "Wundsekretion"),
                        new System.Data.Common.DataColumnMapping("Sekretionsmenge", "Sekretionsmenge"),
                        new System.Data.Common.DataColumnMapping("Wundgeruch", "Wundgeruch"),
                        new System.Data.Common.DataColumnMapping("WundrandIntakt", "WundrandIntakt"),
                        new System.Data.Common.DataColumnMapping("WundrandMazeriert", "WundrandMazeriert"),
                        new System.Data.Common.DataColumnMapping("WundrandUnterminiertZerklueftet", "WundrandUnterminiertZerklueftet"),
                        new System.Data.Common.DataColumnMapping("WundrandGeroetet", "WundrandGeroetet"),
                        new System.Data.Common.DataColumnMapping("WundrandHyperkeratose", "WundrandHyperkeratose"),
                        new System.Data.Common.DataColumnMapping("WundumgebungIntakt", "WundumgebungIntakt"),
                        new System.Data.Common.DataColumnMapping("WundumgebungTrockenPergamentartig", "WundumgebungTrockenPergamentartig"),
                        new System.Data.Common.DataColumnMapping("WundumgebungEkzemOedemRoetung", "WundumgebungEkzemOedemRoetung"),
                        new System.Data.Common.DataColumnMapping("WundumgebungSpannungsblase", "WundumgebungSpannungsblase"),
                        new System.Data.Common.DataColumnMapping("Wundumgebung", "Wundumgebung"),
                        new System.Data.Common.DataColumnMapping("WundrandOedemoesWulstig", "WundrandOedemoesWulstig"),
                        new System.Data.Common.DataColumnMapping("Wundheilungsphase", "Wundheilungsphase"),
                        new System.Data.Common.DataColumnMapping("Wundgrund", "Wundgrund")})});
            this.daWundePos.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDWundePos", System.Data.OleDb.OleDbType.Guid, 16, "IDWundePos")});
            // 
            // oleDbInsertCommand3
            // 
            this.oleDbInsertCommand3.CommandText = resources.GetString("oleDbInsertCommand3.CommandText");
            this.oleDbInsertCommand3.Connection = oleDbConnection1;
            this.oleDbInsertCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDWundePos", System.Data.OleDb.OleDbType.Guid, 0, "IDWundePos"),
            new System.Data.OleDb.OleDbParameter("Bild", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Bild"),
            new System.Data.OleDb.OleDbParameter("Thumbnail", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Thumbnail"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("druckenJN", System.Data.OleDb.OleDbType.Boolean, 0, "druckenJN"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("ZeitpunktBild", System.Data.OleDb.OleDbType.Date, 16, "ZeitpunktBild"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert")});
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = resources.GetString("oleDbUpdateCommand3.CommandText");
            this.oleDbUpdateCommand3.Connection = oleDbConnection1;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDWundePos", System.Data.OleDb.OleDbType.Guid, 0, "IDWundePos"),
            new System.Data.OleDb.OleDbParameter("Bild", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Bild"),
            new System.Data.OleDb.OleDbParameter("Thumbnail", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Thumbnail"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("druckenJN", System.Data.OleDb.OleDbType.Boolean, 0, "druckenJN"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("ZeitpunktBild", System.Data.OleDb.OleDbType.Date, 16, "ZeitpunktBild"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = "DELETE FROM [dbo].[WundePosBilder] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand3.Connection = oleDbConnection1;
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daWundePosBilder
            // 
            this.daWundePosBilder.DeleteCommand = this.oleDbDeleteCommand3;
            this.daWundePosBilder.InsertCommand = this.oleDbInsertCommand3;
            this.daWundePosBilder.SelectCommand = this.oleDbSelectCommand3;
            this.daWundePosBilder.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "WundePosBilder", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDWundePos", "IDWundePos"),
                        new System.Data.Common.DataColumnMapping("Bild", "Bild"),
                        new System.Data.Common.DataColumnMapping("Thumbnail", "Thumbnail"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("druckenJN", "druckenJN"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("ZeitpunktBild", "ZeitpunktBild"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert")})});
            this.daWundePosBilder.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = resources.GetString("oleDbSelectCommand4.CommandText");
            this.oleDbSelectCommand4.Connection = oleDbConnection1;
            this.oleDbSelectCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDWundeKopf", System.Data.OleDb.OleDbType.Guid, 16, "IDWundeKopf")});
            // 
            // oleDbInsertCommand4
            // 
            this.oleDbInsertCommand4.CommandText = resources.GetString("oleDbInsertCommand4.CommandText");
            this.oleDbInsertCommand4.Connection = oleDbConnection1;
            this.oleDbInsertCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDWundeKopf", System.Data.OleDb.OleDbType.Guid, 0, "IDWundeKopf"),
            new System.Data.OleDb.OleDbParameter("VerordnetAm", System.Data.OleDb.OleDbType.Date, 16, "VerordnetAm"),
            new System.Data.OleDb.OleDbParameter("AbgesetztAm", System.Data.OleDb.OleDbType.Date, 16, "AbgesetztAm"),
            new System.Data.OleDb.OleDbParameter("Therapie", System.Data.OleDb.OleDbType.VarChar, 0, "Therapie"),
            new System.Data.OleDb.OleDbParameter("AngeordnetVon", System.Data.OleDb.OleDbType.VarChar, 0, "AngeordnetVon"),
            new System.Data.OleDb.OleDbParameter("AbgesetztVon", System.Data.OleDb.OleDbType.VarChar, 0, "AbgesetztVon"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("Debridement", System.Data.OleDb.OleDbType.VarChar, 0, "Debridement"),
            new System.Data.OleDb.OleDbParameter("Reinigung", System.Data.OleDb.OleDbType.VarChar, 0, "Reinigung"),
            new System.Data.OleDb.OleDbParameter("Wundauflage", System.Data.OleDb.OleDbType.VarChar, 0, "Wundauflage"),
            new System.Data.OleDb.OleDbParameter("Sekundaerverband", System.Data.OleDb.OleDbType.VarChar, 0, "Sekundaerverband"),
            new System.Data.OleDb.OleDbParameter("Fixierung", System.Data.OleDb.OleDbType.VarChar, 0, "Fixierung"),
            new System.Data.OleDb.OleDbParameter("Hyperkeratoseentfernung", System.Data.OleDb.OleDbType.VarChar, 0, "Hyperkeratoseentfernung"),
            new System.Data.OleDb.OleDbParameter("Hautpflege", System.Data.OleDb.OleDbType.VarChar, 0, "Hautpflege"),
            new System.Data.OleDb.OleDbParameter("Zusatzernährung", System.Data.OleDb.OleDbType.VarChar, 0, "Zusatzernährung"),
            new System.Data.OleDb.OleDbParameter("Kompression", System.Data.OleDb.OleDbType.VarChar, 0, "Kompression"),
            new System.Data.OleDb.OleDbParameter("Freillagerung", System.Data.OleDb.OleDbType.VarChar, 0, "Freillagerung"),
            new System.Data.OleDb.OleDbParameter("Wundabstrich", System.Data.OleDb.OleDbType.VarChar, 0, "Wundabstrich"),
            new System.Data.OleDb.OleDbParameter("Wundrandschutz", System.Data.OleDb.OleDbType.VarChar, 0, "Wundrandschutz"),
            new System.Data.OleDb.OleDbParameter("VWIntervall", System.Data.OleDb.OleDbType.VarChar, 0, "VWIntervall"),
            new System.Data.OleDb.OleDbParameter("VidiertJN", System.Data.OleDb.OleDbType.Boolean, 0, "VidiertJN"),
            new System.Data.OleDb.OleDbParameter("VidiertVon", System.Data.OleDb.OleDbType.VarWChar, 0, "VidiertVon"),
            new System.Data.OleDb.OleDbParameter("VidiertAm", System.Data.OleDb.OleDbType.Date, 16, "VidiertAm"),
            new System.Data.OleDb.OleDbParameter("VorgeschlagenVon", System.Data.OleDb.OleDbType.VarChar, 0, "VorgeschlagenVon")});
            // 
            // oleDbUpdateCommand4
            // 
            this.oleDbUpdateCommand4.CommandText = resources.GetString("oleDbUpdateCommand4.CommandText");
            this.oleDbUpdateCommand4.Connection = oleDbConnection1;
            this.oleDbUpdateCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDWundeKopf", System.Data.OleDb.OleDbType.Guid, 16, "IDWundeKopf"),
            new System.Data.OleDb.OleDbParameter("VerordnetAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "VerordnetAm"),
            new System.Data.OleDb.OleDbParameter("AbgesetztAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AbgesetztAm"),
            new System.Data.OleDb.OleDbParameter("Therapie", System.Data.OleDb.OleDbType.Char, 2048, "Therapie"),
            new System.Data.OleDb.OleDbParameter("AngeordnetVon", System.Data.OleDb.OleDbType.Char, 255, "AngeordnetVon"),
            new System.Data.OleDb.OleDbParameter("AbgesetztVon", System.Data.OleDb.OleDbType.Char, 255, "AbgesetztVon"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("Debridement", System.Data.OleDb.OleDbType.Char, 255, "Debridement"),
            new System.Data.OleDb.OleDbParameter("Reinigung", System.Data.OleDb.OleDbType.Char, 255, "Reinigung"),
            new System.Data.OleDb.OleDbParameter("Wundauflage", System.Data.OleDb.OleDbType.Char, 255, "Wundauflage"),
            new System.Data.OleDb.OleDbParameter("Sekundaerverband", System.Data.OleDb.OleDbType.Char, 255, "Sekundaerverband"),
            new System.Data.OleDb.OleDbParameter("Fixierung", System.Data.OleDb.OleDbType.Char, 255, "Fixierung"),
            new System.Data.OleDb.OleDbParameter("Hyperkeratoseentfernung", System.Data.OleDb.OleDbType.Char, 255, "Hyperkeratoseentfernung"),
            new System.Data.OleDb.OleDbParameter("Hautpflege", System.Data.OleDb.OleDbType.Char, 255, "Hautpflege"),
            new System.Data.OleDb.OleDbParameter("Zusatzernährung", System.Data.OleDb.OleDbType.Char, 255, "Zusatzernährung"),
            new System.Data.OleDb.OleDbParameter("Kompression", System.Data.OleDb.OleDbType.Char, 255, "Kompression"),
            new System.Data.OleDb.OleDbParameter("Freillagerung", System.Data.OleDb.OleDbType.Char, 255, "Freillagerung"),
            new System.Data.OleDb.OleDbParameter("Wundabstrich", System.Data.OleDb.OleDbType.Char, 255, "Wundabstrich"),
            new System.Data.OleDb.OleDbParameter("Wundrandschutz", System.Data.OleDb.OleDbType.Char, 100, "Wundrandschutz"),
            new System.Data.OleDb.OleDbParameter("VWIntervall", System.Data.OleDb.OleDbType.Char, 100, "VWIntervall"),
            new System.Data.OleDb.OleDbParameter("VidiertJN", System.Data.OleDb.OleDbType.Boolean, 1, "VidiertJN"),
            new System.Data.OleDb.OleDbParameter("VidiertVon", System.Data.OleDb.OleDbType.WChar, 100, "VidiertVon"),
            new System.Data.OleDb.OleDbParameter("VidiertAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "VidiertAm"),
            new System.Data.OleDb.OleDbParameter("VorgeschlagenVon", System.Data.OleDb.OleDbType.Char, 100, "VorgeschlagenVon"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand4
            // 
            this.oleDbDeleteCommand4.CommandText = resources.GetString("oleDbDeleteCommand4.CommandText");
            this.oleDbDeleteCommand4.Connection = oleDbConnection1;
            this.oleDbDeleteCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDWundeKopf", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDWundeKopf", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VerordnetAm", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VerordnetAm", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VerordnetAm", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VerordnetAm", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AbgesetztAm", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AbgesetztAm", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AbgesetztAm", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AbgesetztAm", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Therapie", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Therapie", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Therapie", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Therapie", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AngeordnetVon", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AngeordnetVon", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AngeordnetVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AngeordnetVon", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AbgesetztVon", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AbgesetztVon", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AbgesetztVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AbgesetztVon", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDBenutzer_Erstellt", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer_Erstellt", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDBenutzer_Geaendert", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer_Geaendert", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_DatumErstellt", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DatumErstellt", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DatumErstellt", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_DatumGeaendert", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DatumGeaendert", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DatumGeaendert", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Debridement", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Debridement", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Reinigung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Reinigung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Wundauflage", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Wundauflage", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Sekundaerverband", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Sekundaerverband", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Fixierung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Fixierung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Hyperkeratoseentfernung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Hyperkeratoseentfernung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Hautpflege", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Hautpflege", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Zusatzernährung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Zusatzernährung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Kompression", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Kompression", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Freillagerung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Freillagerung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Wundabstrich", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Wundabstrich", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Wundrandschutz", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Wundrandschutz", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_VWIntervall", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VWIntervall", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_VidiertJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VidiertJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_VidiertVon", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VidiertVon", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VidiertAm", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VidiertAm", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VidiertAm", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VidiertAm", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_VorgeschlagenVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VorgeschlagenVon", System.Data.DataRowVersion.Original, null)});
            // 
            // daWundeTherapie
            // 
            this.daWundeTherapie.DeleteCommand = this.oleDbDeleteCommand4;
            this.daWundeTherapie.InsertCommand = this.oleDbInsertCommand4;
            this.daWundeTherapie.SelectCommand = this.oleDbSelectCommand4;
            this.daWundeTherapie.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "WundeTherapie", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDWundeKopf", "IDWundeKopf"),
                        new System.Data.Common.DataColumnMapping("VerordnetAm", "VerordnetAm"),
                        new System.Data.Common.DataColumnMapping("AbgesetztAm", "AbgesetztAm"),
                        new System.Data.Common.DataColumnMapping("Therapie", "Therapie"),
                        new System.Data.Common.DataColumnMapping("AngeordnetVon", "AngeordnetVon"),
                        new System.Data.Common.DataColumnMapping("AbgesetztVon", "AbgesetztVon"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("Debridement", "Debridement"),
                        new System.Data.Common.DataColumnMapping("Reinigung", "Reinigung"),
                        new System.Data.Common.DataColumnMapping("Wundauflage", "Wundauflage"),
                        new System.Data.Common.DataColumnMapping("Sekundaerverband", "Sekundaerverband"),
                        new System.Data.Common.DataColumnMapping("Fixierung", "Fixierung"),
                        new System.Data.Common.DataColumnMapping("Hyperkeratoseentfernung", "Hyperkeratoseentfernung"),
                        new System.Data.Common.DataColumnMapping("Hautpflege", "Hautpflege"),
                        new System.Data.Common.DataColumnMapping("Zusatzernährung", "Zusatzernährung"),
                        new System.Data.Common.DataColumnMapping("Kompression", "Kompression"),
                        new System.Data.Common.DataColumnMapping("Freillagerung", "Freillagerung"),
                        new System.Data.Common.DataColumnMapping("Wundabstrich", "Wundabstrich"),
                        new System.Data.Common.DataColumnMapping("Wundrandschutz", "Wundrandschutz"),
                        new System.Data.Common.DataColumnMapping("VWIntervall", "VWIntervall"),
                        new System.Data.Common.DataColumnMapping("VidiertJN", "VidiertJN"),
                        new System.Data.Common.DataColumnMapping("VidiertVon", "VidiertVon"),
                        new System.Data.Common.DataColumnMapping("VidiertAm", "VidiertAm"),
                        new System.Data.Common.DataColumnMapping("VorgeschlagenVon", "VorgeschlagenVon")})});
            this.daWundeTherapie.UpdateCommand = this.oleDbUpdateCommand4;
            // 
            // daWundePosAllThumbs
            // 
            this.daWundePosAllThumbs.SelectCommand = this.oleDbCommand3;
            this.daWundePosAllThumbs.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "WundePosBilder", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDWundePos", "IDWundePos"),
                        new System.Data.Common.DataColumnMapping("Thumbnail", "Thumbnail"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("druckenJN", "druckenJN"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("ZeitpunktBild", "ZeitpunktBild"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("bild", "bild")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDWundeKopf", System.Data.OleDb.OleDbType.Guid, 16, "IDWundeKopf")});
            // 
            // daWundeTherapieByID
            // 
            this.daWundeTherapieByID.SelectCommand = this.oleDbCommand4;
            this.daWundeTherapieByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "WundeTherapie", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDWundeKopf", "IDWundeKopf"),
                        new System.Data.Common.DataColumnMapping("VerordnetAm", "VerordnetAm"),
                        new System.Data.Common.DataColumnMapping("AbgesetztAm", "AbgesetztAm"),
                        new System.Data.Common.DataColumnMapping("Therapie", "Therapie"),
                        new System.Data.Common.DataColumnMapping("AngeordnetVon", "AngeordnetVon"),
                        new System.Data.Common.DataColumnMapping("AbgesetztVon", "AbgesetztVon"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("Debridement", "Debridement"),
                        new System.Data.Common.DataColumnMapping("Reinigung", "Reinigung"),
                        new System.Data.Common.DataColumnMapping("Wundauflage", "Wundauflage"),
                        new System.Data.Common.DataColumnMapping("Sekundaerverband", "Sekundaerverband"),
                        new System.Data.Common.DataColumnMapping("Fixierung", "Fixierung"),
                        new System.Data.Common.DataColumnMapping("Hyperkeratoseentfernung", "Hyperkeratoseentfernung"),
                        new System.Data.Common.DataColumnMapping("Hautpflege", "Hautpflege"),
                        new System.Data.Common.DataColumnMapping("Zusatzernährung", "Zusatzernährung"),
                        new System.Data.Common.DataColumnMapping("Kompression", "Kompression"),
                        new System.Data.Common.DataColumnMapping("Freillagerung", "Freillagerung"),
                        new System.Data.Common.DataColumnMapping("Wundabstrich", "Wundabstrich"),
                        new System.Data.Common.DataColumnMapping("Wundrandschutz", "Wundrandschutz"),
                        new System.Data.Common.DataColumnMapping("VWIntervall", "VWIntervall"),
                        new System.Data.Common.DataColumnMapping("VidiertJN", "VidiertJN"),
                        new System.Data.Common.DataColumnMapping("VidiertVon", "VidiertVon"),
                        new System.Data.Common.DataColumnMapping("VidiertAm", "VidiertAm"),
                        new System.Data.Common.DataColumnMapping("VorgeschlagenVon", "VorgeschlagenVon")})});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daWundePosByID
            // 
            this.daWundePosByID.SelectCommand = this.oleDbCommand5;
            this.daWundePosByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "WundePos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDWundeKopf", "IDWundeKopf"),
                        new System.Data.Common.DataColumnMapping("Erhebungszeitpunkt", "Erhebungszeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Stadium", "Stadium"),
                        new System.Data.Common.DataColumnMapping("Schmerzqualitaet", "Schmerzqualitaet"),
                        new System.Data.Common.DataColumnMapping("Schmerzintensitaet", "Schmerzintensitaet"),
                        new System.Data.Common.DataColumnMapping("NekroseJN", "NekroseJN"),
                        new System.Data.Common.DataColumnMapping("Wundzustand", "Wundzustand"),
                        new System.Data.Common.DataColumnMapping("L", "L"),
                        new System.Data.Common.DataColumnMapping("B", "B"),
                        new System.Data.Common.DataColumnMapping("H", "H"),
                        new System.Data.Common.DataColumnMapping("Erreger", "Erreger"),
                        new System.Data.Common.DataColumnMapping("Infektionszeichen", "Infektionszeichen"),
                        new System.Data.Common.DataColumnMapping("Heilungsverlauf", "Heilungsverlauf"),
                        new System.Data.Common.DataColumnMapping("Heilungstext", "Heilungstext"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("GranulationProz", "GranulationProz"),
                        new System.Data.Common.DataColumnMapping("EpithelisierungProz", "EpithelisierungProz"),
                        new System.Data.Common.DataColumnMapping("FistelnTaschen", "FistelnTaschen"),
                        new System.Data.Common.DataColumnMapping("Wundbelag", "Wundbelag"),
                        new System.Data.Common.DataColumnMapping("WundeFreiliegendeStrukturen", "WundeFreiliegendeStrukturen"),
                        new System.Data.Common.DataColumnMapping("Wundsekretion", "Wundsekretion"),
                        new System.Data.Common.DataColumnMapping("Sekretionsmenge", "Sekretionsmenge"),
                        new System.Data.Common.DataColumnMapping("Wundgeruch", "Wundgeruch"),
                        new System.Data.Common.DataColumnMapping("WundrandIntakt", "WundrandIntakt"),
                        new System.Data.Common.DataColumnMapping("WundrandMazeriert", "WundrandMazeriert"),
                        new System.Data.Common.DataColumnMapping("WundrandUnterminiertZerklueftet", "WundrandUnterminiertZerklueftet"),
                        new System.Data.Common.DataColumnMapping("WundrandGeroetet", "WundrandGeroetet"),
                        new System.Data.Common.DataColumnMapping("WundrandHyperkeratose", "WundrandHyperkeratose"),
                        new System.Data.Common.DataColumnMapping("WundumgebungIntakt", "WundumgebungIntakt"),
                        new System.Data.Common.DataColumnMapping("WundumgebungTrockenPergamentartig", "WundumgebungTrockenPergamentartig"),
                        new System.Data.Common.DataColumnMapping("WundumgebungEkzemOedemRoetung", "WundumgebungEkzemOedemRoetung"),
                        new System.Data.Common.DataColumnMapping("WundumgebungSpannungsblase", "WundumgebungSpannungsblase"),
                        new System.Data.Common.DataColumnMapping("Wundumgebung", "Wundumgebung"),
                        new System.Data.Common.DataColumnMapping("WundrandOedemoesWulstig", "WundrandOedemoesWulstig"),
                        new System.Data.Common.DataColumnMapping("Wundheilungsphase", "Wundheilungsphase"),
                        new System.Data.Common.DataColumnMapping("Wundgrund", "Wundgrund")})});
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = resources.GetString("oleDbCommand5.CommandText");
            this.oleDbCommand5.Connection = oleDbConnection1;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daWundeKopf;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        private System.Data.OleDb.OleDbDataAdapter daWundePos;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
        private System.Data.OleDb.OleDbDataAdapter daWundeTherapie;
        private System.Data.OleDb.OleDbDataAdapter daWundePosAllThumbs;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbDataAdapter daWundeTherapieByID;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        public System.Data.OleDb.OleDbDataAdapter daWundePosBilder;
        private System.Data.OleDb.OleDbDataAdapter daWundePosByID;
        private System.Data.OleDb.OleDbCommand oleDbCommand5;
    }
}
