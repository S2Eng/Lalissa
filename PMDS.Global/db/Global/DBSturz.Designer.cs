namespace PMDS.DB.Global
{
    partial class DBSturz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBSturz));
            this.daSturzByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dbConn = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            // 
            // daSturzByID
            // 
            this.daSturzByID.DeleteCommand = this.oleDbDeleteCommand1;
            this.daSturzByID.InsertCommand = this.oleDbInsertCommand1;
            this.daSturzByID.SelectCommand = this.oleDbSelectCommand1;
            this.daSturzByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblSturzprotokoll", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDStandardprozedur", "IDStandardprozedur"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("NamePatient", "NamePatient"),
                        new System.Data.Common.DataColumnMapping("PatGebDat", "PatGebDat"),
                        new System.Data.Common.DataColumnMapping("Wohnbereich", "Wohnbereich"),
                        new System.Data.Common.DataColumnMapping("Zimmer", "Zimmer"),
                        new System.Data.Common.DataColumnMapping("SturzDatum", "SturzDatum"),
                        new System.Data.Common.DataColumnMapping("SturzOrt", "SturzOrt"),
                        new System.Data.Common.DataColumnMapping("SturzStellung", "SturzStellung"),
                        new System.Data.Common.DataColumnMapping("SturzErstellt", "SturzErstellt"),
                        new System.Data.Common.DataColumnMapping("SituationWie", "SituationWie"),
                        new System.Data.Common.DataColumnMapping("SituationGehilfen", "SituationGehilfen"),
                        new System.Data.Common.DataColumnMapping("SituationKleidung", "SituationKleidung"),
                        new System.Data.Common.DataColumnMapping("SituationSchuhe", "SituationSchuhe"),
                        new System.Data.Common.DataColumnMapping("HergangWoZuletztGesehen", "HergangWoZuletztGesehen"),
                        new System.Data.Common.DataColumnMapping("HergangKonnteBewohnerSchildern", "HergangKonnteBewohnerSchildern"),
                        new System.Data.Common.DataColumnMapping("HergangSchilderungBewohnerJN", "HergangSchilderungBewohnerJN"),
                        new System.Data.Common.DataColumnMapping("HergangSchilderungBewohner", "HergangSchilderungBewohner"),
                        new System.Data.Common.DataColumnMapping("UmständeHilfebedarf", "UmständeHilfebedarf"),
                        new System.Data.Common.DataColumnMapping("UmständeSachgerechteNutzung", "UmständeSachgerechteNutzung"),
                        new System.Data.Common.DataColumnMapping("UmständeFixierungJN", "UmständeFixierungJN"),
                        new System.Data.Common.DataColumnMapping("UmständeFixierung", "UmständeFixierung"),
                        new System.Data.Common.DataColumnMapping("UmständePflegekräfteAnwesend", "UmständePflegekräfteAnwesend"),
                        new System.Data.Common.DataColumnMapping("UmständeKlingelJN", "UmständeKlingelJN"),
                        new System.Data.Common.DataColumnMapping("UmständeBewohnervsrschuldenJN", "UmständeBewohnervsrschuldenJN"),
                        new System.Data.Common.DataColumnMapping("UmständeBewohnervsrschulden", "UmständeBewohnervsrschulden"),
                        new System.Data.Common.DataColumnMapping("UmständeKlinikVerschuldenJN", "UmständeKlinikVerschuldenJN"),
                        new System.Data.Common.DataColumnMapping("UmständeKlinikVerschulden", "UmständeKlinikVerschulden"),
                        new System.Data.Common.DataColumnMapping("UmständeFremdverschuldenJN", "UmständeFremdverschuldenJN"),
                        new System.Data.Common.DataColumnMapping("UmständeFremdverschulden", "UmständeFremdverschulden"),
                        new System.Data.Common.DataColumnMapping("UmständeVorereignisJN", "UmständeVorereignisJN"),
                        new System.Data.Common.DataColumnMapping("UmständeVorereignis", "UmständeVorereignis"),
                        new System.Data.Common.DataColumnMapping("GesundheitSchädenJN", "GesundheitSchädenJN"),
                        new System.Data.Common.DataColumnMapping("GesundheitSchäden", "GesundheitSchäden"),
                        new System.Data.Common.DataColumnMapping("GesundheitBlutzucker", "GesundheitBlutzucker"),
                        new System.Data.Common.DataColumnMapping("GesundheitBlutdruckSystolisch", "GesundheitBlutdruckSystolisch"),
                        new System.Data.Common.DataColumnMapping("GesundheitBlutdruckDiastolisch", "GesundheitBlutdruckDiastolisch"),
                        new System.Data.Common.DataColumnMapping("GesundheitPuls", "GesundheitPuls"),
                        new System.Data.Common.DataColumnMapping("GesundheitMental", "GesundheitMental"),
                        new System.Data.Common.DataColumnMapping("GesundheitErstversorgungJN", "GesundheitErstversorgungJN"),
                        new System.Data.Common.DataColumnMapping("GesundheitErstversorgung", "GesundheitErstversorgung"),
                        new System.Data.Common.DataColumnMapping("GesundheitErgebnis", "GesundheitErgebnis"),
                        new System.Data.Common.DataColumnMapping("GesundheitTransferKrankenhausJN", "GesundheitTransferKrankenhausJN"),
                        new System.Data.Common.DataColumnMapping("GesundheitTransferKrankenhaus", "GesundheitTransferKrankenhaus"),
                        new System.Data.Common.DataColumnMapping("InformationKontaktpersonJN", "InformationKontaktpersonJN"),
                        new System.Data.Common.DataColumnMapping("InformationKontaktperson", "InformationKontaktperson"),
                        new System.Data.Common.DataColumnMapping("InformationPflegepersonKontakt", "InformationPflegepersonKontakt"),
                        new System.Data.Common.DataColumnMapping("InformationPDLZeitpunkt", "InformationPDLZeitpunkt"),
                        new System.Data.Common.DataColumnMapping("InformationPDLVonWemInformiert", "InformationPDLVonWemInformiert"),
                        new System.Data.Common.DataColumnMapping("InformationArztJN", "InformationArztJN"),
                        new System.Data.Common.DataColumnMapping("InformationArzt", "InformationArzt"),
                        new System.Data.Common.DataColumnMapping("InformationArztPflegepersonHatInformiert", "InformationArztPflegepersonHatInformiert"),
                        new System.Data.Common.DataColumnMapping("AnalyseMedikamente", "AnalyseMedikamente"),
                        new System.Data.Common.DataColumnMapping("AnalyseKrankheitsbilder", "AnalyseKrankheitsbilder"),
                        new System.Data.Common.DataColumnMapping("AnalyseInkontinenz", "AnalyseInkontinenz"),
                        new System.Data.Common.DataColumnMapping("AnalyseEingeschränkteMobilität", "AnalyseEingeschränkteMobilität"),
                        new System.Data.Common.DataColumnMapping("AnalyseSchwindel", "AnalyseSchwindel"),
                        new System.Data.Common.DataColumnMapping("AnalyseErnährung", "AnalyseErnährung"),
                        new System.Data.Common.DataColumnMapping("AnalyseMaßnahmen", "AnalyseMaßnahmen"),
                        new System.Data.Common.DataColumnMapping("Anmerkungen", "Anmerkungen"),
                        new System.Data.Common.DataColumnMapping("DatumUnterschriftPflegedienstleitung", "DatumUnterschriftPflegedienstleitung"),
                        new System.Data.Common.DataColumnMapping("DatumUnterschriftPflegekraft", "DatumUnterschriftPflegekraft")})});
            this.daSturzByID.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [tblSturzprotokoll] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.dbConn;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dbConn
            // 
            this.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.dbConn;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDStandardprozedur", System.Data.OleDb.OleDbType.Guid, 0, "IDStandardprozedur"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("NamePatient", System.Data.OleDb.OleDbType.VarChar, 0, "NamePatient"),
            new System.Data.OleDb.OleDbParameter("PatGebDat", System.Data.OleDb.OleDbType.Date, 16, "PatGebDat"),
            new System.Data.OleDb.OleDbParameter("Wohnbereich", System.Data.OleDb.OleDbType.VarChar, 0, "Wohnbereich"),
            new System.Data.OleDb.OleDbParameter("Zimmer", System.Data.OleDb.OleDbType.VarChar, 0, "Zimmer"),
            new System.Data.OleDb.OleDbParameter("SturzDatum", System.Data.OleDb.OleDbType.Date, 16, "SturzDatum"),
            new System.Data.OleDb.OleDbParameter("SturzOrt", System.Data.OleDb.OleDbType.LongVarChar, 0, "SturzOrt"),
            new System.Data.OleDb.OleDbParameter("SturzStellung", System.Data.OleDb.OleDbType.LongVarChar, 0, "SturzStellung"),
            new System.Data.OleDb.OleDbParameter("SturzErstellt", System.Data.OleDb.OleDbType.LongVarChar, 0, "SturzErstellt"),
            new System.Data.OleDb.OleDbParameter("SituationWie", System.Data.OleDb.OleDbType.LongVarChar, 0, "SituationWie"),
            new System.Data.OleDb.OleDbParameter("SituationGehilfen", System.Data.OleDb.OleDbType.LongVarChar, 0, "SituationGehilfen"),
            new System.Data.OleDb.OleDbParameter("SituationKleidung", System.Data.OleDb.OleDbType.LongVarChar, 0, "SituationKleidung"),
            new System.Data.OleDb.OleDbParameter("SituationSchuhe", System.Data.OleDb.OleDbType.LongVarChar, 0, "SituationSchuhe"),
            new System.Data.OleDb.OleDbParameter("HergangWoZuletztGesehen", System.Data.OleDb.OleDbType.LongVarChar, 0, "HergangWoZuletztGesehen"),
            new System.Data.OleDb.OleDbParameter("HergangKonnteBewohnerSchildern", System.Data.OleDb.OleDbType.LongVarChar, 0, "HergangKonnteBewohnerSchildern"),
            new System.Data.OleDb.OleDbParameter("HergangSchilderungBewohnerJN", System.Data.OleDb.OleDbType.Boolean, 0, "HergangSchilderungBewohnerJN"),
            new System.Data.OleDb.OleDbParameter("HergangSchilderungBewohner", System.Data.OleDb.OleDbType.LongVarChar, 0, "HergangSchilderungBewohner"),
            new System.Data.OleDb.OleDbParameter("UmständeHilfebedarf", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeHilfebedarf"),
            new System.Data.OleDb.OleDbParameter("UmständeSachgerechteNutzung", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeSachgerechteNutzung"),
            new System.Data.OleDb.OleDbParameter("UmständeFixierungJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmständeFixierungJN"),
            new System.Data.OleDb.OleDbParameter("UmständeFixierung", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeFixierung"),
            new System.Data.OleDb.OleDbParameter("UmständePflegekräfteAnwesend", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständePflegekräfteAnwesend"),
            new System.Data.OleDb.OleDbParameter("UmständeKlingelJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmständeKlingelJN"),
            new System.Data.OleDb.OleDbParameter("UmständeBewohnervsrschuldenJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmständeBewohnervsrschuldenJN"),
            new System.Data.OleDb.OleDbParameter("UmständeBewohnervsrschulden", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeBewohnervsrschulden"),
            new System.Data.OleDb.OleDbParameter("UmständeKlinikVerschuldenJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmständeKlinikVerschuldenJN"),
            new System.Data.OleDb.OleDbParameter("UmständeKlinikVerschulden", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeKlinikVerschulden"),
            new System.Data.OleDb.OleDbParameter("UmständeFremdverschuldenJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmständeFremdverschuldenJN"),
            new System.Data.OleDb.OleDbParameter("UmständeFremdverschulden", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeFremdverschulden"),
            new System.Data.OleDb.OleDbParameter("UmständeVorereignisJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmständeVorereignisJN"),
            new System.Data.OleDb.OleDbParameter("UmständeVorereignis", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeVorereignis"),
            new System.Data.OleDb.OleDbParameter("GesundheitSchädenJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesundheitSchädenJN"),
            new System.Data.OleDb.OleDbParameter("GesundheitSchäden", System.Data.OleDb.OleDbType.LongVarChar, 0, "GesundheitSchäden"),
            new System.Data.OleDb.OleDbParameter("GesundheitBlutzucker", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "GesundheitBlutzucker", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("GesundheitBlutdruckSystolisch", System.Data.OleDb.OleDbType.Integer, 0, "GesundheitBlutdruckSystolisch"),
            new System.Data.OleDb.OleDbParameter("GesundheitBlutdruckDiastolisch", System.Data.OleDb.OleDbType.Integer, 0, "GesundheitBlutdruckDiastolisch"),
            new System.Data.OleDb.OleDbParameter("GesundheitPuls", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "GesundheitPuls", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("GesundheitMental", System.Data.OleDb.OleDbType.LongVarChar, 0, "GesundheitMental"),
            new System.Data.OleDb.OleDbParameter("GesundheitErstversorgungJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesundheitErstversorgungJN"),
            new System.Data.OleDb.OleDbParameter("GesundheitErstversorgung", System.Data.OleDb.OleDbType.LongVarChar, 0, "GesundheitErstversorgung"),
            new System.Data.OleDb.OleDbParameter("GesundheitErgebnis", System.Data.OleDb.OleDbType.LongVarChar, 0, "GesundheitErgebnis"),
            new System.Data.OleDb.OleDbParameter("GesundheitTransferKrankenhausJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesundheitTransferKrankenhausJN"),
            new System.Data.OleDb.OleDbParameter("GesundheitTransferKrankenhaus", System.Data.OleDb.OleDbType.LongVarChar, 0, "GesundheitTransferKrankenhaus"),
            new System.Data.OleDb.OleDbParameter("InformationKontaktpersonJN", System.Data.OleDb.OleDbType.Boolean, 0, "InformationKontaktpersonJN"),
            new System.Data.OleDb.OleDbParameter("InformationKontaktperson", System.Data.OleDb.OleDbType.LongVarChar, 0, "InformationKontaktperson"),
            new System.Data.OleDb.OleDbParameter("InformationPflegepersonKontakt", System.Data.OleDb.OleDbType.LongVarChar, 0, "InformationPflegepersonKontakt"),
            new System.Data.OleDb.OleDbParameter("InformationPDLZeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "InformationPDLZeitpunkt"),
            new System.Data.OleDb.OleDbParameter("InformationPDLVonWemInformiert", System.Data.OleDb.OleDbType.LongVarChar, 0, "InformationPDLVonWemInformiert"),
            new System.Data.OleDb.OleDbParameter("InformationArztJN", System.Data.OleDb.OleDbType.Boolean, 0, "InformationArztJN"),
            new System.Data.OleDb.OleDbParameter("InformationArzt", System.Data.OleDb.OleDbType.LongVarChar, 0, "InformationArzt"),
            new System.Data.OleDb.OleDbParameter("InformationArztPflegepersonHatInformiert", System.Data.OleDb.OleDbType.LongVarChar, 0, "InformationArztPflegepersonHatInformiert"),
            new System.Data.OleDb.OleDbParameter("AnalyseMedikamente", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseMedikamente"),
            new System.Data.OleDb.OleDbParameter("AnalyseKrankheitsbilder", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseKrankheitsbilder"),
            new System.Data.OleDb.OleDbParameter("AnalyseInkontinenz", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseInkontinenz"),
            new System.Data.OleDb.OleDbParameter("AnalyseEingeschränkteMobilität", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseEingeschränkteMobilität"),
            new System.Data.OleDb.OleDbParameter("AnalyseSchwindel", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseSchwindel"),
            new System.Data.OleDb.OleDbParameter("AnalyseErnährung", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseErnährung"),
            new System.Data.OleDb.OleDbParameter("AnalyseMaßnahmen", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseMaßnahmen"),
            new System.Data.OleDb.OleDbParameter("Anmerkungen", System.Data.OleDb.OleDbType.LongVarChar, 0, "Anmerkungen"),
            new System.Data.OleDb.OleDbParameter("DatumUnterschriftPflegedienstleitung", System.Data.OleDb.OleDbType.LongVarChar, 0, "DatumUnterschriftPflegedienstleitung"),
            new System.Data.OleDb.OleDbParameter("DatumUnterschriftPflegekraft", System.Data.OleDb.OleDbType.LongVarChar, 0, "DatumUnterschriftPflegekraft")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.dbConn;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDStandardprozedur", System.Data.OleDb.OleDbType.Guid, 16, "IDStandardprozedur")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.dbConn;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDStandardprozedur", System.Data.OleDb.OleDbType.Guid, 0, "IDStandardprozedur"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("NamePatient", System.Data.OleDb.OleDbType.VarChar, 0, "NamePatient"),
            new System.Data.OleDb.OleDbParameter("PatGebDat", System.Data.OleDb.OleDbType.Date, 16, "PatGebDat"),
            new System.Data.OleDb.OleDbParameter("Wohnbereich", System.Data.OleDb.OleDbType.VarChar, 0, "Wohnbereich"),
            new System.Data.OleDb.OleDbParameter("Zimmer", System.Data.OleDb.OleDbType.VarChar, 0, "Zimmer"),
            new System.Data.OleDb.OleDbParameter("SturzDatum", System.Data.OleDb.OleDbType.Date, 16, "SturzDatum"),
            new System.Data.OleDb.OleDbParameter("SturzOrt", System.Data.OleDb.OleDbType.LongVarChar, 0, "SturzOrt"),
            new System.Data.OleDb.OleDbParameter("SturzStellung", System.Data.OleDb.OleDbType.LongVarChar, 0, "SturzStellung"),
            new System.Data.OleDb.OleDbParameter("SturzErstellt", System.Data.OleDb.OleDbType.LongVarChar, 0, "SturzErstellt"),
            new System.Data.OleDb.OleDbParameter("SituationWie", System.Data.OleDb.OleDbType.LongVarChar, 0, "SituationWie"),
            new System.Data.OleDb.OleDbParameter("SituationGehilfen", System.Data.OleDb.OleDbType.LongVarChar, 0, "SituationGehilfen"),
            new System.Data.OleDb.OleDbParameter("SituationKleidung", System.Data.OleDb.OleDbType.LongVarChar, 0, "SituationKleidung"),
            new System.Data.OleDb.OleDbParameter("SituationSchuhe", System.Data.OleDb.OleDbType.LongVarChar, 0, "SituationSchuhe"),
            new System.Data.OleDb.OleDbParameter("HergangWoZuletztGesehen", System.Data.OleDb.OleDbType.LongVarChar, 0, "HergangWoZuletztGesehen"),
            new System.Data.OleDb.OleDbParameter("HergangKonnteBewohnerSchildern", System.Data.OleDb.OleDbType.LongVarChar, 0, "HergangKonnteBewohnerSchildern"),
            new System.Data.OleDb.OleDbParameter("HergangSchilderungBewohnerJN", System.Data.OleDb.OleDbType.Boolean, 0, "HergangSchilderungBewohnerJN"),
            new System.Data.OleDb.OleDbParameter("HergangSchilderungBewohner", System.Data.OleDb.OleDbType.LongVarChar, 0, "HergangSchilderungBewohner"),
            new System.Data.OleDb.OleDbParameter("UmständeHilfebedarf", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeHilfebedarf"),
            new System.Data.OleDb.OleDbParameter("UmständeSachgerechteNutzung", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeSachgerechteNutzung"),
            new System.Data.OleDb.OleDbParameter("UmständeFixierungJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmständeFixierungJN"),
            new System.Data.OleDb.OleDbParameter("UmständeFixierung", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeFixierung"),
            new System.Data.OleDb.OleDbParameter("UmständePflegekräfteAnwesend", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständePflegekräfteAnwesend"),
            new System.Data.OleDb.OleDbParameter("UmständeKlingelJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmständeKlingelJN"),
            new System.Data.OleDb.OleDbParameter("UmständeBewohnervsrschuldenJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmständeBewohnervsrschuldenJN"),
            new System.Data.OleDb.OleDbParameter("UmständeBewohnervsrschulden", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeBewohnervsrschulden"),
            new System.Data.OleDb.OleDbParameter("UmständeKlinikVerschuldenJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmständeKlinikVerschuldenJN"),
            new System.Data.OleDb.OleDbParameter("UmständeKlinikVerschulden", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeKlinikVerschulden"),
            new System.Data.OleDb.OleDbParameter("UmständeFremdverschuldenJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmständeFremdverschuldenJN"),
            new System.Data.OleDb.OleDbParameter("UmständeFremdverschulden", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeFremdverschulden"),
            new System.Data.OleDb.OleDbParameter("UmständeVorereignisJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmständeVorereignisJN"),
            new System.Data.OleDb.OleDbParameter("UmständeVorereignis", System.Data.OleDb.OleDbType.LongVarChar, 0, "UmständeVorereignis"),
            new System.Data.OleDb.OleDbParameter("GesundheitSchädenJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesundheitSchädenJN"),
            new System.Data.OleDb.OleDbParameter("GesundheitSchäden", System.Data.OleDb.OleDbType.LongVarChar, 0, "GesundheitSchäden"),
            new System.Data.OleDb.OleDbParameter("GesundheitBlutzucker", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "GesundheitBlutzucker", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("GesundheitBlutdruckSystolisch", System.Data.OleDb.OleDbType.Integer, 0, "GesundheitBlutdruckSystolisch"),
            new System.Data.OleDb.OleDbParameter("GesundheitBlutdruckDiastolisch", System.Data.OleDb.OleDbType.Integer, 0, "GesundheitBlutdruckDiastolisch"),
            new System.Data.OleDb.OleDbParameter("GesundheitPuls", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "GesundheitPuls", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("GesundheitMental", System.Data.OleDb.OleDbType.LongVarChar, 0, "GesundheitMental"),
            new System.Data.OleDb.OleDbParameter("GesundheitErstversorgungJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesundheitErstversorgungJN"),
            new System.Data.OleDb.OleDbParameter("GesundheitErstversorgung", System.Data.OleDb.OleDbType.LongVarChar, 0, "GesundheitErstversorgung"),
            new System.Data.OleDb.OleDbParameter("GesundheitErgebnis", System.Data.OleDb.OleDbType.LongVarChar, 0, "GesundheitErgebnis"),
            new System.Data.OleDb.OleDbParameter("GesundheitTransferKrankenhausJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesundheitTransferKrankenhausJN"),
            new System.Data.OleDb.OleDbParameter("GesundheitTransferKrankenhaus", System.Data.OleDb.OleDbType.LongVarChar, 0, "GesundheitTransferKrankenhaus"),
            new System.Data.OleDb.OleDbParameter("InformationKontaktpersonJN", System.Data.OleDb.OleDbType.Boolean, 0, "InformationKontaktpersonJN"),
            new System.Data.OleDb.OleDbParameter("InformationKontaktperson", System.Data.OleDb.OleDbType.LongVarChar, 0, "InformationKontaktperson"),
            new System.Data.OleDb.OleDbParameter("InformationPflegepersonKontakt", System.Data.OleDb.OleDbType.LongVarChar, 0, "InformationPflegepersonKontakt"),
            new System.Data.OleDb.OleDbParameter("InformationPDLZeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "InformationPDLZeitpunkt"),
            new System.Data.OleDb.OleDbParameter("InformationPDLVonWemInformiert", System.Data.OleDb.OleDbType.LongVarChar, 0, "InformationPDLVonWemInformiert"),
            new System.Data.OleDb.OleDbParameter("InformationArztJN", System.Data.OleDb.OleDbType.Boolean, 0, "InformationArztJN"),
            new System.Data.OleDb.OleDbParameter("InformationArzt", System.Data.OleDb.OleDbType.LongVarChar, 0, "InformationArzt"),
            new System.Data.OleDb.OleDbParameter("InformationArztPflegepersonHatInformiert", System.Data.OleDb.OleDbType.LongVarChar, 0, "InformationArztPflegepersonHatInformiert"),
            new System.Data.OleDb.OleDbParameter("AnalyseMedikamente", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseMedikamente"),
            new System.Data.OleDb.OleDbParameter("AnalyseKrankheitsbilder", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseKrankheitsbilder"),
            new System.Data.OleDb.OleDbParameter("AnalyseInkontinenz", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseInkontinenz"),
            new System.Data.OleDb.OleDbParameter("AnalyseEingeschränkteMobilität", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseEingeschränkteMobilität"),
            new System.Data.OleDb.OleDbParameter("AnalyseSchwindel", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseSchwindel"),
            new System.Data.OleDb.OleDbParameter("AnalyseErnährung", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseErnährung"),
            new System.Data.OleDb.OleDbParameter("AnalyseMaßnahmen", System.Data.OleDb.OleDbType.LongVarChar, 0, "AnalyseMaßnahmen"),
            new System.Data.OleDb.OleDbParameter("Anmerkungen", System.Data.OleDb.OleDbType.LongVarChar, 0, "Anmerkungen"),
            new System.Data.OleDb.OleDbParameter("DatumUnterschriftPflegedienstleitung", System.Data.OleDb.OleDbType.LongVarChar, 0, "DatumUnterschriftPflegedienstleitung"),
            new System.Data.OleDb.OleDbParameter("DatumUnterschriftPflegekraft", System.Data.OleDb.OleDbType.LongVarChar, 0, "DatumUnterschriftPflegekraft"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        public System.Data.OleDb.OleDbDataAdapter daSturzByID;
        private System.Data.OleDb.OleDbConnection dbConn;
    }
}
