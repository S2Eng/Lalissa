using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data.OleDb;
using PMDS.Abrechnung.Global;
using PMDS.Data.Patient;
using PMDS.Global;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Global.db.Global.ds_abrechnung.unwichtig;
using PMDS.Global.db.Patient;
using System.Data;

namespace PMDS.Calc.Admin.DB
{



	public class DBPatientKostentraeger : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbDataAdapter daPatientKostentraeger;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daPatientKostentraegerByID;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbDataAdapter daByKostentraeger;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private System.Data.OleDb.OleDbDataAdapter daKostentraegerByID;
        private System.Data.OleDb.OleDbCommand oleDbCommand5;
        private System.Data.OleDb.OleDbDataAdapter daPatientStation;
        private System.Data.OleDb.OleDbCommand oleDbCommand7;
        private System.Data.OleDb.OleDbDataAdapter daAllgemKostentraeger;
        private System.Data.OleDb.OleDbCommand oleDbCommand8;
        private OleDbDataAdapter daAllEntries;
        private OleDbCommand oleDbCommand10;
        private OleDbDataAdapter daKostentraegerXXXX;
        private OleDbCommand oleDbCommand6;
        private OleDbDataAdapter daByID;
        private OleDbCommand oleDbCommand12;
        private OleDbDataAdapter daDistinctPatientenMonatJahrAbrechnung;
        private OleDbCommand oleDbCommand9;
        private OleDbDataAdapter daKlientenAlleSelbstzahler;
        private OleDbCommand oleDbCommand11;
        private OleDbCommand oleDbInsertCommand;
        private OleDbDataAdapter daPatKostenträgerGültigBis;
        private OleDbCommand oleDbCommand1;
        private OleDbCommand oleDbCommand13;
        private OleDbCommand oleDbCommand14;
        private OleDbDataAdapter daPatientLeistungsplanGültigBis;
        private OleDbCommand oleDbCommand15;
        private OleDbCommand oleDbCommand16;
        private OleDbCommand oleDbCommand17;
        private OleDbDataAdapter daPatientTaschengeldKostentraeger;
        private OleDbCommand oleDbCommand18;
        private OleDbCommand oleDbCommand19;
        private OleDbCommand oleDbCommand20;
		private System.ComponentModel.Container components = null;


        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPatientKostentraeger));
            this.daPatientKostentraeger = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPatientKostentraegerByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daByKostentraeger = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.daKostentraegerByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.daPatientStation = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.daAllgemKostentraeger = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            this.daAllEntries = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand10 = new System.Data.OleDb.OleDbCommand();
            this.daKostentraegerXXXX = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand6 = new System.Data.OleDb.OleDbCommand();
            this.daByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand12 = new System.Data.OleDb.OleDbCommand();
            this.daDistinctPatientenMonatJahrAbrechnung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand9 = new System.Data.OleDb.OleDbCommand();
            this.daKlientenAlleSelbstzahler = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand11 = new System.Data.OleDb.OleDbCommand();
            this.daPatKostenträgerGültigBis = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand13 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand14 = new System.Data.OleDb.OleDbCommand();
            this.daPatientLeistungsplanGültigBis = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand15 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand16 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand17 = new System.Data.OleDb.OleDbCommand();
            this.daPatientTaschengeldKostentraeger = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand18 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand19 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand20 = new System.Data.OleDb.OleDbCommand();
            // 
            // daPatientKostentraeger
            // 
            this.daPatientKostentraeger.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPatientKostentraeger.InsertCommand = this.oleDbInsertCommand;
            this.daPatientKostentraeger.SelectCommand = this.oleDbSelectCommand1;
            this.daPatientKostentraeger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientKostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("enumKostentraegerart", "enumKostentraegerart"),
                        new System.Data.Common.DataColumnMapping("BetragErrechnetJN", "BetragErrechnetJN"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("VorauszahlungJN", "VorauszahlungJN"),
                        new System.Data.Common.DataColumnMapping("RechnungJN", "RechnungJN"),
                        new System.Data.Common.DataColumnMapping("RechnungTyp", "RechnungTyp")})});
            this.daPatientKostentraeger.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = resources.GetString("oleDbDeleteCommand1.CommandText");
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPatient", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDKostentraeger", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GueltigAb", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GueltigAb", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_GueltigBis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_GueltigBis", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_enumKostentraegerart", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "enumKostentraegerart", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_BetragErrechnetJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BetragErrechnetJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Betrag", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Betrag", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Betrag", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Betrag", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ErfasstAm", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ErfasstAm", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ErfasstAm", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ErfasstAm", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AbgerechnetBis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AbgerechnetBis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AbgerechnetBis", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AbgerechnetBis", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_VorauszahlungJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VorauszahlungJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_RechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RechnungJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_RechnungTyp", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RechnungTyp", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = resources.GetString("oleDbInsertCommand.CommandText");
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 16, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("enumKostentraegerart", System.Data.OleDb.OleDbType.Integer, 0, "enumKostentraegerart"),
            new System.Data.OleDb.OleDbParameter("BetragErrechnetJN", System.Data.OleDb.OleDbType.Boolean, 0, "BetragErrechnetJN"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Double, 0, "Betrag"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.Date, 16, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.Date, 16, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("VorauszahlungJN", System.Data.OleDb.OleDbType.Boolean, 0, "VorauszahlungJN"),
            new System.Data.OleDb.OleDbParameter("RechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "RechnungJN"),
            new System.Data.OleDb.OleDbParameter("RechnungTyp", System.Data.OleDb.OleDbType.Integer, 0, "RechnungTyp")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 16, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("enumKostentraegerart", System.Data.OleDb.OleDbType.Integer, 0, "enumKostentraegerart"),
            new System.Data.OleDb.OleDbParameter("BetragErrechnetJN", System.Data.OleDb.OleDbType.Boolean, 0, "BetragErrechnetJN"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Double, 0, "Betrag"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.Date, 16, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.Date, 16, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("VorauszahlungJN", System.Data.OleDb.OleDbType.Boolean, 0, "VorauszahlungJN"),
            new System.Data.OleDb.OleDbParameter("RechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "RechnungJN"),
            new System.Data.OleDb.OleDbParameter("RechnungTyp", System.Data.OleDb.OleDbType.Integer, 0, "RechnungTyp"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPatient", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDKostentraeger", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GueltigAb", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GueltigAb", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_GueltigBis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_GueltigBis", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_enumKostentraegerart", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "enumKostentraegerart", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_BetragErrechnetJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BetragErrechnetJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Betrag", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Betrag", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Betrag", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Betrag", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ErfasstAm", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ErfasstAm", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ErfasstAm", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ErfasstAm", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AbgerechnetBis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AbgerechnetBis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AbgerechnetBis", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AbgerechnetBis", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_VorauszahlungJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VorauszahlungJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_RechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RechnungJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_RechnungTyp", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RechnungTyp", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatientKostentraegerByID
            // 
            this.daPatientKostentraegerByID.SelectCommand = this.oleDbCommand3;
            this.daPatientKostentraegerByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Kostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("enumKostentraegerart", "enumKostentraegerart"),
                        new System.Data.Common.DataColumnMapping("BetragErrechnetJN", "BetragErrechnetJN"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Strasse", "Strasse"),
                        new System.Data.Common.DataColumnMapping("PLZ", "PLZ"),
                        new System.Data.Common.DataColumnMapping("Ort", "Ort"),
                        new System.Data.Common.DataColumnMapping("Rechnungsempfaenger", "Rechnungsempfaenger"),
                        new System.Data.Common.DataColumnMapping("Rechnungsanschrift", "Rechnungsanschrift"),
                        new System.Data.Common.DataColumnMapping("BLZ", "BLZ"),
                        new System.Data.Common.DataColumnMapping("Kontonr", "Kontonr"),
                        new System.Data.Common.DataColumnMapping("Bank", "Bank"),
                        new System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"),
                        new System.Data.Common.DataColumnMapping("ErlagscheingebuehrJN", "ErlagscheingebuehrJN")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daByKostentraeger
            // 
            this.daByKostentraeger.SelectCommand = this.oleDbCommand4;
            this.daByKostentraeger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientKostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("enumKostentraegerart", "enumKostentraegerart"),
                        new System.Data.Common.DataColumnMapping("BetragErrechnetJN", "BetragErrechnetJN"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("VorauszahlungJN", "VorauszahlungJN"),
                        new System.Data.Common.DataColumnMapping("RechnungJN", "RechnungJN")})});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 16, "IDKostentraeger")});
            // 
            // daKostentraegerByID
            // 
            this.daKostentraegerByID.SelectCommand = this.oleDbCommand5;
            this.daKostentraegerByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Kostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Strasse", "Strasse"),
                        new System.Data.Common.DataColumnMapping("PLZ", "PLZ"),
                        new System.Data.Common.DataColumnMapping("Ort", "Ort"),
                        new System.Data.Common.DataColumnMapping("Rechnungsempfaenger", "Rechnungsempfaenger"),
                        new System.Data.Common.DataColumnMapping("Rechnungsanschrift", "Rechnungsanschrift"),
                        new System.Data.Common.DataColumnMapping("BLZ", "BLZ"),
                        new System.Data.Common.DataColumnMapping("Kontonr", "Kontonr"),
                        new System.Data.Common.DataColumnMapping("Bank", "Bank"),
                        new System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"),
                        new System.Data.Common.DataColumnMapping("ErlagscheingebuehrJN", "ErlagscheingebuehrJN"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("TransferleistungJN", "TransferleistungJN"),
                        new System.Data.Common.DataColumnMapping("TaschengeldJN", "TaschengeldJN"),
                        new System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"),
                        new System.Data.Common.DataColumnMapping("PatientbezogenJN", "PatientbezogenJN")})});
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = resources.GetString("oleDbCommand5.CommandText");
            this.oleDbCommand5.Connection = this.oleDbConnection1;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daPatientStation
            // 
            this.daPatientStation.SelectCommand = this.oleDbCommand7;
            this.daPatientStation.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("UrlaubText", "UrlaubText"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt")})});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = resources.GetString("oleDbCommand7.CommandText");
            this.oleDbCommand7.Connection = this.oleDbConnection1;
            this.oleDbCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daAllgemKostentraeger
            // 
            this.daAllgemKostentraeger.SelectCommand = this.oleDbCommand8;
            this.daAllgemKostentraeger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Kostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Strasse", "Strasse"),
                        new System.Data.Common.DataColumnMapping("PLZ", "PLZ"),
                        new System.Data.Common.DataColumnMapping("Ort", "Ort"),
                        new System.Data.Common.DataColumnMapping("Rechnungsempfaenger", "Rechnungsempfaenger"),
                        new System.Data.Common.DataColumnMapping("Rechnungsanschrift", "Rechnungsanschrift"),
                        new System.Data.Common.DataColumnMapping("BLZ", "BLZ"),
                        new System.Data.Common.DataColumnMapping("Kontonr", "Kontonr"),
                        new System.Data.Common.DataColumnMapping("Bank", "Bank"),
                        new System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"),
                        new System.Data.Common.DataColumnMapping("ErlagscheingebuehrJN", "ErlagscheingebuehrJN"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("TransferleistungJN", "TransferleistungJN"),
                        new System.Data.Common.DataColumnMapping("TaschengeldJN", "TaschengeldJN"),
                        new System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"),
                        new System.Data.Common.DataColumnMapping("PatientbezogenJN", "PatientbezogenJN")})});
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = resources.GetString("oleDbCommand8.CommandText");
            this.oleDbCommand8.Connection = this.oleDbConnection1;
            // 
            // daAllEntries
            // 
            this.daAllEntries.SelectCommand = this.oleDbCommand10;
            this.daAllEntries.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientKostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("enumKostentraegerart", "enumKostentraegerart"),
                        new System.Data.Common.DataColumnMapping("BetragErrechnetJN", "BetragErrechnetJN"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("VorauszahlungJN", "VorauszahlungJN"),
                        new System.Data.Common.DataColumnMapping("RechnungJN", "RechnungJN"),
                        new System.Data.Common.DataColumnMapping("RechnungTyp", "RechnungTyp")})});
            // 
            // oleDbCommand10
            // 
            this.oleDbCommand10.CommandText = resources.GetString("oleDbCommand10.CommandText");
            this.oleDbCommand10.Connection = this.oleDbConnection1;
            // 
            // daKostentraegerXXXX
            // 
            this.daKostentraegerXXXX.SelectCommand = this.oleDbCommand6;
            this.daKostentraegerXXXX.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Kostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Strasse", "Strasse"),
                        new System.Data.Common.DataColumnMapping("PLZ", "PLZ"),
                        new System.Data.Common.DataColumnMapping("Ort", "Ort"),
                        new System.Data.Common.DataColumnMapping("Rechnungsempfaenger", "Rechnungsempfaenger"),
                        new System.Data.Common.DataColumnMapping("Rechnungsanschrift", "Rechnungsanschrift"),
                        new System.Data.Common.DataColumnMapping("BLZ", "BLZ"),
                        new System.Data.Common.DataColumnMapping("Kontonr", "Kontonr"),
                        new System.Data.Common.DataColumnMapping("Bank", "Bank"),
                        new System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"),
                        new System.Data.Common.DataColumnMapping("ErlagscheingebuehrJN", "ErlagscheingebuehrJN"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("TransferleistungJN", "TransferleistungJN"),
                        new System.Data.Common.DataColumnMapping("TaschengeldJN", "TaschengeldJN"),
                        new System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"),
                        new System.Data.Common.DataColumnMapping("PatientbezogenJN", "PatientbezogenJN")})});
            // 
            // oleDbCommand6
            // 
            this.oleDbCommand6.CommandText = resources.GetString("oleDbCommand6.CommandText");
            this.oleDbCommand6.Connection = this.oleDbConnection1;
            this.oleDbCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 8, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 8, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("GueltigBis1", System.Data.OleDb.OleDbType.Date, 8, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("GueltigAb1", System.Data.OleDb.OleDbType.Date, 8, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis2", System.Data.OleDb.OleDbType.Date, 8, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("GueltigBis3", System.Data.OleDb.OleDbType.Date, 8, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("GueltigAb2", System.Data.OleDb.OleDbType.Date, 8, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis4", System.Data.OleDb.OleDbType.Date, 8, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("GueltigAb3", System.Data.OleDb.OleDbType.Date, 8, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigAb4", System.Data.OleDb.OleDbType.Date, 8, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis5", System.Data.OleDb.OleDbType.Date, 8, "GueltigBis")});
            // 
            // daByID
            // 
            this.daByID.SelectCommand = this.oleDbCommand12;
            this.daByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientKostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("enumKostentraegerart", "enumKostentraegerart"),
                        new System.Data.Common.DataColumnMapping("BetragErrechnetJN", "BetragErrechnetJN"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("VorauszahlungJN", "VorauszahlungJN"),
                        new System.Data.Common.DataColumnMapping("RechnungJN", "RechnungJN"),
                        new System.Data.Common.DataColumnMapping("RechnungTyp", "RechnungTyp")})});
            // 
            // oleDbCommand12
            // 
            this.oleDbCommand12.CommandText = resources.GetString("oleDbCommand12.CommandText");
            this.oleDbCommand12.Connection = this.oleDbConnection1;
            this.oleDbCommand12.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daDistinctPatientenMonatJahrAbrechnung
            // 
            this.daDistinctPatientenMonatJahrAbrechnung.SelectCommand = this.oleDbCommand9;
            this.daDistinctPatientenMonatJahrAbrechnung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abrechnung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient")})});
            // 
            // oleDbCommand9
            // 
            this.oleDbCommand9.CommandText = "SELECT DISTINCT IDPatient\r\nFROM            Abrechnung\r\nWHERE        (Monat = ?) A" +
    "ND (Jahr = ?) AND (GeloeschtJN = 0)";
            this.oleDbCommand9.Connection = this.oleDbConnection1;
            this.oleDbCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Monat", System.Data.OleDb.OleDbType.Integer, 4, "Monat"),
            new System.Data.OleDb.OleDbParameter("Jahr", System.Data.OleDb.OleDbType.Integer, 4, "Jahr")});
            // 
            // daKlientenAlleSelbstzahler
            // 
            this.daKlientenAlleSelbstzahler.SelectCommand = this.oleDbCommand11;
            this.daKlientenAlleSelbstzahler.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("UrlaubText", "UrlaubText"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt")})});
            // 
            // oleDbCommand11
            // 
            this.oleDbCommand11.CommandText = resources.GetString("oleDbCommand11.CommandText");
            this.oleDbCommand11.Connection = this.oleDbConnection1;
            // 
            // daPatKostenträgerGültigBis
            // 
            this.daPatKostenträgerGültigBis.DeleteCommand = this.oleDbCommand1;
            this.daPatKostenträgerGültigBis.SelectCommand = this.oleDbCommand13;
            this.daPatKostenträgerGültigBis.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientKostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis")})});
            this.daPatKostenträgerGültigBis.UpdateCommand = this.oleDbCommand14;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [PatientKostentraeger] WHERE (([ID] = ?) AND ([IDPatient] = ?) AND ((" +
    "? = 1 AND [GueltigBis] IS NULL) OR ([GueltigBis] = ?)))";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPatient", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_GueltigBis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_GueltigBis", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand13
            // 
            this.oleDbCommand13.CommandText = "SELECT        ID, IDPatient, GueltigBis\r\nFROM            PatientKostentraeger\r\nWH" +
    "ERE        (IDPatient = ?) AND    ((GueltigBis > ?) or  (GueltigBis is null ))";
            this.oleDbCommand13.Connection = this.oleDbConnection1;
            this.oleDbCommand13.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 8, "GueltigBis")});
            // 
            // oleDbCommand14
            // 
            this.oleDbCommand14.CommandText = "UPDATE [PatientKostentraeger] SET [ID] = ?, [IDPatient] = ?, [GueltigBis] = ? WHE" +
    "RE (([ID] = ?) AND ([IDPatient] = ?) AND ((? = 1 AND [GueltigBis] IS NULL) OR ([" +
    "GueltigBis] = ?)))";
            this.oleDbCommand14.Connection = this.oleDbConnection1;
            this.oleDbCommand14.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPatient", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_GueltigBis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_GueltigBis", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatientLeistungsplanGültigBis
            // 
            this.daPatientLeistungsplanGültigBis.DeleteCommand = this.oleDbCommand15;
            this.daPatientLeistungsplanGültigBis.SelectCommand = this.oleDbCommand16;
            this.daPatientLeistungsplanGültigBis.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientLeistungsplan", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis")})});
            this.daPatientLeistungsplanGültigBis.UpdateCommand = this.oleDbCommand17;
            // 
            // oleDbCommand15
            // 
            this.oleDbCommand15.CommandText = "DELETE FROM [PatientLeistungsplan] WHERE (([ID] = ?) AND ([IDPatient] = ?) AND ((" +
    "? = 1 AND [GueltigBis] IS NULL) OR ([GueltigBis] = ?)))";
            this.oleDbCommand15.Connection = this.oleDbConnection1;
            this.oleDbCommand15.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPatient", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_GueltigBis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_GueltigBis", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand16
            // 
            this.oleDbCommand16.CommandText = "SELECT        ID, IDPatient, GueltigBis\r\nFROM            PatientLeistungsplan\r\nWH" +
    "ERE        (IDPatient = ?) AND    ((GueltigBis > ?) or  (GueltigBis is null ))";
            this.oleDbCommand16.Connection = this.oleDbConnection1;
            this.oleDbCommand16.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 8, "GueltigBis")});
            // 
            // oleDbCommand17
            // 
            this.oleDbCommand17.CommandText = "UPDATE [PatientLeistungsplan] SET [ID] = ?, [IDPatient] = ?, [GueltigBis] = ? WHE" +
    "RE (([ID] = ?) AND ([IDPatient] = ?) AND ((? = 1 AND [GueltigBis] IS NULL) OR ([" +
    "GueltigBis] = ?)))";
            this.oleDbCommand17.Connection = this.oleDbConnection1;
            this.oleDbCommand17.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPatient", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_GueltigBis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_GueltigBis", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatientTaschengeldKostentraeger
            // 
            this.daPatientTaschengeldKostentraeger.DeleteCommand = this.oleDbCommand18;
            this.daPatientTaschengeldKostentraeger.SelectCommand = this.oleDbCommand19;
            this.daPatientTaschengeldKostentraeger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientTaschengeldKostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis")})});
            this.daPatientTaschengeldKostentraeger.UpdateCommand = this.oleDbCommand20;
            // 
            // oleDbCommand18
            // 
            this.oleDbCommand18.CommandText = "DELETE FROM [PatientTaschengeldKostentraeger] WHERE (([ID] = ?) AND ([IDPatient] " +
    "= ?) AND ((? = 1 AND [GueltigBis] IS NULL) OR ([GueltigBis] = ?)))";
            this.oleDbCommand18.Connection = this.oleDbConnection1;
            this.oleDbCommand18.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPatient", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_GueltigBis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_GueltigBis", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand19
            // 
            this.oleDbCommand19.CommandText = "SELECT        ID, IDPatient, GueltigBis\r\nFROM            PatientTaschengeldKosten" +
    "traeger \r\nWHERE        (IDPatient = ?) AND    ((GueltigBis > ?) or  (GueltigBis " +
    "is null ))";
            this.oleDbCommand19.Connection = this.oleDbConnection1;
            this.oleDbCommand19.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 8, "GueltigBis")});
            // 
            // oleDbCommand20
            // 
            this.oleDbCommand20.CommandText = "UPDATE [PatientTaschengeldKostentraeger] SET [ID] = ?, [IDPatient] = ?, [GueltigB" +
    "is] = ? WHERE (([ID] = ?) AND ([IDPatient] = ?) AND ((? = 1 AND [GueltigBis] IS " +
    "NULL) OR ([GueltigBis] = ?)))";
            this.oleDbCommand20.Connection = this.oleDbConnection1;
            this.oleDbCommand20.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPatient", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPatient", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_GueltigBis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_GueltigBis", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GueltigBis", System.Data.DataRowVersion.Original, null)});

        }
        #endregion




		public DBPatientKostentraeger(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();

		}

		public DBPatientKostentraeger()
		{
			InitializeComponent();

		}

        public dsPatientKostentraeger.PatientKostentraegerDataTable Read()
        {
            dsPatientKostentraeger.PatientKostentraegerDataTable dt = new dsPatientKostentraeger.PatientKostentraegerDataTable();
            DataBase.Fill(daAllEntries, dt);
            return dt;
        }
        public dsPatientKostentraeger Read2()
        {
            dsPatientKostentraeger ds = new dsPatientKostentraeger();
            DataBase.Fill(daAllEntries, ds.PatientKostentraeger);
            return ds;
        }
        public Abrechnung.Global.dsPatientKostentraegerByID.KostentraegerRow ReadByID(Guid IDPatientKostentraeger)
        {
            Abrechnung.Global.dsPatientKostentraegerByID.KostentraegerDataTable dt = new Abrechnung.Global.dsPatientKostentraegerByID.KostentraegerDataTable();
            daPatientKostentraegerByID.SelectCommand.Parameters[0].Value = IDPatientKostentraeger;
            DataBase.Fill(daPatientKostentraegerByID, dt);
            
            if (dt.Count == 0)
                return null;
            return dt[0];
        }

        public dsPatientKostentraeger.PatientKostentraegerRow GetByID(Guid ID)
        {
            dsPatientKostentraeger.PatientKostentraegerDataTable dt = new dsPatientKostentraeger.PatientKostentraegerDataTable();
            daByID.SelectCommand.Parameters[0].Value = ID;
            DataBase.Fill(daByID, dt);
            return dt.Count > 0 ? dt[0] : null;
        }
        public dsPatientKostentraeger.PatientKostentraegerDataTable Read(Guid IDPatient, bool TransferkostentraegerJN)
        {
            dsPatientKostentraeger.PatientKostentraegerDataTable dt = this.Read(IDPatient);
            string sWhere = TransferkostentraegerJN ? "enumKostentraegerart <> " + ((int)Kostentraegerart.Transferleistung).ToString() : "enumKostentraegerart = " + ((int)Kostentraegerart.Transferleistung).ToString();
            dsPatientKostentraeger.PatientKostentraegerRow[] rows = (dsPatientKostentraeger.PatientKostentraegerRow[])dt.Select(sWhere);

            foreach (dsPatientKostentraeger.PatientKostentraegerRow r in rows)
                r.Delete();
            dt.AcceptChanges();
            return dt;
        }
		public dsPatientKostentraeger.PatientKostentraegerDataTable Read(Guid IDPatient)
		{
			dsPatientKostentraeger.PatientKostentraegerDataTable dt = new dsPatientKostentraeger.PatientKostentraegerDataTable();
			daPatientKostentraeger.SelectCommand.Parameters[0].Value = IDPatient;
			DataBase.Fill(daPatientKostentraeger, dt);
			return dt;
		}

        public dsPatientKostentraeger.PatientKostentraegerDataTable ReadByKostentraeger(Guid IDKostentraeger)
        {
            dsPatientKostentraeger.PatientKostentraegerDataTable dt = new dsPatientKostentraeger.PatientKostentraegerDataTable();
            daByKostentraeger.SelectCommand.Parameters[0].Value = IDKostentraeger;
            DataBase.Fill(daByKostentraeger, dt);
            return dt;
        }

        public void GetKlientenKostentraeger(dsKlientenKostentraeger ds, DateTime from, DateTime to)
        {
            GetKlientenKostentraeger(ds, from, to, true);
        }

        public void GetKlientenKostentraeger(dsKlientenKostentraeger ds, Guid IDKostentraeger, DateTime from, DateTime to)
        {
            GetKlientenKostentraeger(ds, IDKostentraeger, from, to, true);
        }

        public void GetKlientenKostentraeger(dsKlientenKostentraeger ds, DateTime from, DateTime to, bool bEntlassene)
        {
            ds.Clear();
            ds.AcceptChanges();

            DataBase.Fill(daAllgemKostentraeger, ds.Kostentraeger);
            OleDbDataAdapter da;
            foreach (dsKlientenKostentraeger.KostentraegerRow r in ds.Kostentraeger)
            {
                da = GetDaKlientenByKostentraeger(r.ID, from, to, bEntlassene, false);
                DataBase.Fill(da, ds.PatientKostentraeger);
            }
        }

        public void GetKlientenKostentraeger(dsKlientenKostentraeger ds, Guid IDKostentraeger, DateTime from, DateTime to, bool bEntlassene)
        {
            ds.Clear();
            ds.AcceptChanges();

            daKostentraegerByID.SelectCommand.Parameters[0].Value = IDKostentraeger;
            DataBase.Fill(daKostentraegerByID, ds.Kostentraeger);
            OleDbDataAdapter da;
            foreach (dsKlientenKostentraeger.KostentraegerRow r in ds.Kostentraeger)
            {
                da = GetDaKlientenByKostentraeger(r.ID, from, to, bEntlassene, false);
                DataBase.Fill(da, ds.PatientKostentraeger);
            }
        }

        private OleDbDataAdapter GetDaKlientenByKostentraeger(Guid IDKostentraeger, DateTime gueltigab, DateTime gueltigBis, bool bEntlassene, bool Restzahler)
        {
            OleDbCommand cmd = new OleDbCommand();
            StringBuilder sb = new StringBuilder();

            //Änderung nach 02.09.2008 MDA
            sb.Append("SELECT  PatientKostentraeger.ID, PatientKostentraeger.IDPatient, PatientKostentraeger.IDKostentraeger, ");
            sb.Append("PatientKostentraeger.GueltigAb, PatientKostentraeger.GueltigBis, PatientKostentraeger.enumKostentraegerart, ");
            sb.Append("PatientKostentraeger.BetragErrechnetJN, PatientKostentraeger.Betrag, PatientKostentraeger.ErfasstAm, ");
            sb.Append("PatientKostentraeger.IDBenutzer, PatientKostentraeger.AbgerechnetBis ");

            if (bEntlassene)
            {
                sb.Append("FROM PatientKostentraeger INNER JOIN Patient ON PatientKostentraeger.IDPatient = Patient.ID ");
                sb.Append("WHERE (PatientKostentraeger.IDKostentraeger = ?) AND ");
            }
            else
            {
                sb.Append("FROM UrlaubVerlauf RIGHT OUTER JOIN ");
                sb.Append("Aufenthalt ON UrlaubVerlauf.ID = Aufenthalt.IDUrlaub LEFT OUTER JOIN ");
                sb.Append("AufenthaltVerlauf INNER JOIN ");
                sb.Append("Abteilung ON AufenthaltVerlauf.IDAbteilung_Nach = Abteilung.ID LEFT OUTER JOIN ");
                sb.Append("Bereich ON AufenthaltVerlauf.IDBereich = Bereich.ID ON Aufenthalt.IDAufenthaltVerlauf = AufenthaltVerlauf.ID RIGHT OUTER JOIN ");
                sb.Append("Patient ON Aufenthalt.IDPatient = Patient.ID INNER JOIN ");
                sb.Append("PatientKostentraeger ON Patient.ID = PatientKostentraeger.IDPatient INNER JOIN ");
                sb.Append("Kostentraeger ON Kostentraeger.ID =PatientKostentraeger.IDKostentraeger ");
                sb.Append("WHERE AufenthaltVerlauf.IDAufenthalt is not null and Aufenthalt.Entlassungszeitpunkt is null AND (PatientKostentraeger.IDKostentraeger = ?) AND ");
            }
            
            sb.Append(" ((PatientKostentraeger.GueltigBis is null and PatientKostentraeger.GueltigAb <=  ?) or ");
            sb.Append("(PatientKostentraeger.GueltigBis is not null AND not (");
            sb.Append("(PatientKostentraeger.GueltigAb < ? and PatientKostentraeger.GueltigBis < ?) or ");
            sb.Append("(PatientKostentraeger.GueltigAb > ? and PatientKostentraeger.GueltigBis > ?)))) "); 

            if (Restzahler)
                sb.Append(" AND PatientKostentraeger.BetragErrechnetJN = 1 ");

            sb.Append("ORDER BY Patient.Nachname, Patient.Vorname, PatientKostentraeger.GueltigAb, PatientKostentraeger.GueltigBis");

            cmd.CommandText = sb.ToString();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.SelectCommand.Parameters.AddWithValue("IDKostentraeger", IDKostentraeger);
            da.SelectCommand.Parameters.AddWithValue("GueltigAb", gueltigBis);
            da.SelectCommand.Parameters.AddWithValue("GueltigAb1", gueltigab);
            da.SelectCommand.Parameters.AddWithValue("GueltigBis", gueltigab);
            da.SelectCommand.Parameters.AddWithValue("GueltigAb2", gueltigBis);
            da.SelectCommand.Parameters.AddWithValue("GueltigBis1", gueltigBis);
            return da;
        }
        public void GetRestzahlerKlienten(dsKlientenKostentraeger ds, DateTime from, DateTime to, bool bEntlassene)
        {
            ds.Clear();
            ds.AcceptChanges();

            DataBase.Fill(daAllgemKostentraeger, ds.Kostentraeger);
            OleDbDataAdapter da;
            foreach (dsKlientenKostentraeger.KostentraegerRow r in ds.Kostentraeger)
            {
                da = GetDaKlientenByKostentraeger(r.ID, from, to, bEntlassene, true);
                DataBase.Fill(da, ds.PatientKostentraeger);
            }
        }

        public void GetRestzahlerKlienten(dsKlientenKostentraeger ds, Guid IDKostentraeger, DateTime from, DateTime to, bool bEntlassene)
        {
            ds.Clear();
            ds.AcceptChanges();

            daKostentraegerByID.SelectCommand.Parameters[0].Value = IDKostentraeger;
            DataBase.Fill(daKostentraegerByID, ds.Kostentraeger);
            OleDbDataAdapter da;
            foreach (dsKlientenKostentraeger.KostentraegerRow r in ds.Kostentraeger)
            {
                da = GetDaKlientenByKostentraeger(r.ID, from, to, bEntlassene, true);
                DataBase.Fill(da, ds.PatientKostentraeger);
            }

        }

        public System.Data.DataTable getIDKlientDistinctAbrechMonatxy(DateTime from)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            daDistinctPatientenMonatJahrAbrechnung.SelectCommand.Parameters[0].Value = from.Month;
            daDistinctPatientenMonatJahrAbrechnung.SelectCommand.Parameters[1].Value = from.Year;
            DataBase.Fill(daDistinctPatientenMonatJahrAbrechnung, dt);
            return dt;
        }

        public dsPatientStation.PatientDataTable KlientenByKostentraeger(Guid IDKostentraeger, DateTime von, DateTime bis)
        {
            //osxy 140701 - Table und da austauschen - SQL im OneNote
            dsPatientStation.PatientDataTable dt = new dsPatientStation.PatientDataTable();
            daPatientStation.SelectCommand.Parameters[0].Value = IDKostentraeger;
            DataBase.Fill(daPatientStation, dt);
            return dt;
        }

        public bool deletePatientKostenträger(Guid IDKost)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmd.Connection = RBU.DataBase.CONNECTION;
            cmd.CommandText = " Delete from  PatientKostentraeger  WHERE IDKostentraeger = ? ";
            cmd.Parameters.Add("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 16, "IDKostentraeger").Value = IDKost;
            cmd.ExecuteNonQuery();
            return true;
        }
        public dsPatientStation.PatientDataTable klientenAlleSelbstzahler(bool TransferleistungJN, bool PatientbezogenJN  )
        {
            dsPatientStation.PatientDataTable dt = new dsPatientStation.PatientDataTable();
            DataBase.Fill(daKlientenAlleSelbstzahler, dt);
            return dt;
        }

		public void Update(dsPatientKostentraeger.PatientKostentraegerDataTable dt)
		{
			DataBase.Update(daPatientKostentraeger, dt);
		}
        
        public dsPatientKostentraeger.PatientKostentraegerRow New(dsPatientKostentraeger.PatientKostentraegerDataTable dt, Guid IDPatient, Guid IDKostentraeger)
        {
            dsPatientKostentraeger.PatientKostentraegerRow r = dt.AddPatientKostentraegerRow(Guid.NewGuid(), IDPatient, IDKostentraeger, DateTime.Now.Date, DateTime.Now.Date, 0, false, 0, DateTime.Now, Guid.Empty, DateTime.Now, false, false, (int)PMDS.Calc.Logic.eBillTyp.Rechnung);
            r.SetGueltigBisNull();
            r.IDBenutzer = ENV.USERID;
            r.SetAbgerechnetBisNull();
            return r;
        }
        public bool gültigBisAufEntl_alleLeistKost(Guid IDPatient, DateTime dtEntlassung)
        {
            DateTime dtEntlassungRead0 = new DateTime(dtEntlassung.Year, dtEntlassung.Month, dtEntlassung.Day, 0, 0, 0);
            DateTime dtEntlassungRead23 = new DateTime(dtEntlassung.Year, dtEntlassung.Month, dtEntlassung.Day, 23, 59, 59);

            PMDS.Global.db.Global.ds_abrechnung.dsPatientKostenträgerGültigBis dsPatKost = new PMDS.Global.db.Global.ds_abrechnung.dsPatientKostenträgerGültigBis();
            daPatKostenträgerGültigBis.SelectCommand.Parameters[0].Value = IDPatient;
            // daPatKostenträgerGültigBis.SelectCommand.Parameters[1].Value = dtEntlassungRead23;
            daPatKostenträgerGültigBis.SelectCommand.Parameters[1].Value = dtEntlassungRead23;
            DataBase.Fill(this.daPatKostenträgerGültigBis, dsPatKost);
            foreach (PMDS.Global.db.Global.ds_abrechnung.dsPatientKostenträgerGültigBis.PatientKostentraegerRow r in dsPatKost.PatientKostentraeger.Rows)
            {
                r.GueltigBis = dtEntlassungRead0;
            }
            this.daPatKostenträgerGültigBis.Update(dsPatKost);

            PMDS.Global.db.Global.ds_abrechnung.dsPatientTaschengeldKostentraegerGültigBis dsPatTaschKost = new PMDS.Global.db.Global.ds_abrechnung.dsPatientTaschengeldKostentraegerGültigBis();
            daPatientTaschengeldKostentraeger.SelectCommand.Parameters[0].Value = IDPatient;
            //daPatientTaschengeldKostentraeger.SelectCommand.Parameters[1].Value = dtEntlassungRead23;
            daPatientTaschengeldKostentraeger.SelectCommand.Parameters[1].Value = dtEntlassungRead23;
            DataBase.Fill(this.daPatientTaschengeldKostentraeger, dsPatTaschKost);
            foreach (PMDS.Global.db.Global.ds_abrechnung.dsPatientTaschengeldKostentraegerGültigBis.PatientTaschengeldKostentraegerRow r in dsPatTaschKost.PatientTaschengeldKostentraeger.Rows)
            {
                r.GueltigBis = dtEntlassungRead0;
            }
            this.daPatientTaschengeldKostentraeger.Update(dsPatTaschKost);

            PMDS.Global.db.Global.ds_abrechnung.dsPatientLeistungsplanGültigBis dsPatLeist = new PMDS.Global.db.Global.ds_abrechnung.dsPatientLeistungsplanGültigBis();
            daPatientLeistungsplanGültigBis.SelectCommand.Parameters[0].Value = IDPatient;
            //daPatientLeistungsplanGültigBis.SelectCommand.Parameters[1].Value = dtEntlassungRead23;
            daPatientLeistungsplanGültigBis.SelectCommand.Parameters[1].Value = dtEntlassungRead23;
            DataBase.Fill(this.daPatientLeistungsplanGültigBis, dsPatLeist);
            foreach (PMDS.Global.db.Global.ds_abrechnung.dsPatientLeistungsplanGültigBis.PatientLeistungsplanRow r in dsPatLeist.PatientLeistungsplan.Rows)
            {
                r.GueltigBis = dtEntlassungRead0;
            }
            this.daPatientLeistungsplanGültigBis.Update(dsPatLeist);

            return true;

            //OleDbCommand cmd = new OleDbCommand();
            //cmd.CommandText = "Update PatientKostentraeger set bis = ?, Beendigungsgrund = ?, Beschreibung = ? where IDPatient = ? and Medizinischertyp = ? and not von is null and bis is null";
            //cmd.Parameters.AddWithValue("bis", dtEnde);
            //cmd.Parameters.AddWithValue("Beendigungsgrund", sEndegrund);
            //cmd.Parameters.AddWithValue("Beschreibung", sBeschreibung);
            //cmd.Parameters.AddWithValue("IDPatient", IDPatient);
            //cmd.Parameters.AddWithValue("Medizinischertyp", Medizinischertyp);
            //DataBase.EcecuteNonQuery(cmd);
        }

	}
}
