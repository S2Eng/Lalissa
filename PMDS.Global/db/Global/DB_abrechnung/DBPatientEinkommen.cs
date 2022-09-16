using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.OleDb;
using System.Text;
using PMDS.Abrechnung.Global;
using PMDS.Data.Global;
using RBU;



namespace PMDS.Calc.Admin.DB
{
	/// <summary>
	/// Summary description for DBPatientEinkommen.
	/// </summary>
	public class DBPatientEinkommen : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbDataAdapter daPatientEinkommen;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbDataAdapter daPatienten;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private OleDbDataAdapter daPatientEinkommenByID;
        private OleDbCommand oleDbCommand1;
        private OleDbCommand oleDbCommand4;
        private OleDbCommand oleDbCommand5;
        private OleDbDataAdapter daTransferKostentraeger;
        private OleDbCommand oleDbCommand8;
        private OleDbDataAdapter daByKostentraeger;
        private OleDbCommand oleDbCommand10;
        private OleDbCommand oleDbCommand12;
        private OleDbDataAdapter daAllEntries;
        private OleDbCommand oleDbCommand9;
		private System.ComponentModel.Container components = null;

		public DBPatientEinkommen(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();

		}

		public DBPatientEinkommen()
		{
			InitializeComponent();

		}

        /// <summary>
        /// Alle Datensätze
        /// </summary>
        /// <returns></returns>
        //public dsPatientEinkommen.PatientEinkommenDataTable Read(Guid IDKlinik)
        //{
        //    dsPatientEinkommen.PatientEinkommenDataTable dt = new dsPatientEinkommen.PatientEinkommenDataTable();
        //    daPatientEinkommen.SelectCommand.Parameters[0].Value = IDKlinik;
        //    DataBase.Fill(daAllEntries, dt);
        //    return dt;
        //}

		public dsPatientEinkommen.PatientEinkommenDataTable Read(Guid IDPatient, Guid IDKlinik)
		{
			dsPatientEinkommen.PatientEinkommenDataTable dt = new dsPatientEinkommen.PatientEinkommenDataTable();
			daPatientEinkommen.SelectCommand.Parameters[0].Value = IDPatient;
            daPatientEinkommen.SelectCommand.Parameters[1].Value = IDKlinik;
			DataBase.Fill(daPatientEinkommen, dt);
			return dt;
		}

        //neu  nach 17.01.2008 MDA
        public dsPatientEinkommen.PatientEinkommenDataTable Read(Guid IDKostentraeger, List<Guid> lIDPatient, DateTime GueltigAb, Guid IDKlinik)
        {
            dsPatientEinkommen.PatientEinkommenDataTable dt = new dsPatientEinkommen.PatientEinkommenDataTable();

            if (lIDPatient.Count == 0)
                lIDPatient.Add(Guid.Empty);

            OleDbCommand cmd = new OleDbCommand();
            string txt = daPatienten.SelectCommand.CommandText + " AND IDKlinik = ? AND IDKostentraeger = ?  AND IDPatient IN({0})";

            StringBuilder sb = new StringBuilder();

            foreach (Guid id in lIDPatient)
            {
                if (sb.Length > 0) sb.Append(", ");
                sb.Append("'" + id.ToString() + "'");
            }

            cmd.CommandText = string.Format(txt, sb.ToString());
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.SelectCommand.Parameters.Add(new OleDbParameter { ParameterName = "GueltigAb", OleDbType = OleDbType.Date, Value = GueltigAb });
            da.SelectCommand.Parameters.AddWithValue("IDKlinik", IDKlinik);
            da.SelectCommand.Parameters.AddWithValue("IDKostentraeger", IDKostentraeger);
            DataBase.Fill(da, dt);
            return dt;
        }

        //Neu nach 05.02.2008 MDA
        public dsPatientEinkommen.PatientEinkommenRow ReadByID(Guid IDPatientEinkommen)
        {
            dsPatientEinkommen.PatientEinkommenDataTable dt = new dsPatientEinkommen.PatientEinkommenDataTable();
            daPatientEinkommenByID.SelectCommand.Parameters[0].Value = IDPatientEinkommen;
            DataBase.Fill(daPatientEinkommenByID, dt);
            //if (dt.Count == 0)
            //    throw new Exception(string.Format("Die PatientKostenträgerID {0} wurde nicht gefunden - wahrscheinlich ist die Zuordnung aus der Datenbank entfernt worden - DBPatientKostentraeger::ReadByID", IDPatientKostentraeger));
            if (dt.Count == 0)
                return null;
            return dt[0];
        }

        public void Update(dsPatientEinkommen.PatientEinkommenDataTable dt)
		{
			DataBase.Update(daPatientEinkommen, dt);
		}

        public dsPatientEinkommen.PatientEinkommenDataTable ReadOnlyTransferKostentraeger(Guid IDPatient, Guid IDKlinik)
        {
            dsPatientEinkommen.PatientEinkommenDataTable dt = new dsPatientEinkommen.PatientEinkommenDataTable();
            daTransferKostentraeger.SelectCommand.Parameters[0].Value = IDPatient;
            daTransferKostentraeger.SelectCommand.Parameters[1].Value = IDKlinik;
            DataBase.Fill(daTransferKostentraeger, dt);
            return dt;
        }

        public dsPatientEinkommen.PatientEinkommenDataTable ReadOnlyNotTransferEinkommen(Guid IDPatient, Guid IDKlinik)
        {
            dsPatientEinkommen.PatientEinkommenDataTable dt = new dsPatientEinkommen.PatientEinkommenDataTable();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = daPatientEinkommen.SelectCommand.CommandText + " AND TransferleistungJN = 0";
            
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.SelectCommand.Parameters.AddWithValue("IDPatient", IDPatient);
            da.SelectCommand.Parameters.AddWithValue("IDKlinik", IDKlinik);
            DataBase.Fill(da, dt);
            return dt;
        }

        public dsPatientEinkommen.PatientEinkommenDataTable ReadByKostentraeger(Guid IDKostentraeger, Guid IDKlinik)
        {
            dsPatientEinkommen.PatientEinkommenDataTable dt = new dsPatientEinkommen.PatientEinkommenDataTable();
            daByKostentraeger.SelectCommand.Parameters[0].Value = IDKostentraeger;
            daByKostentraeger.SelectCommand.Parameters[1].Value = IDKlinik;
            DataBase.Fill(daByKostentraeger, dt);
            return dt;
        }

        public dsPatientEinkommen.PatientEinkommenDataTable ReadByKostentraeger(List<Guid> lIDKostentraeger, Guid IDKlinik)
        {
            dsPatientEinkommen ds = new dsPatientEinkommen();

            foreach (Guid id in lIDKostentraeger)
            {
                daByKostentraeger.SelectCommand.Parameters[0].Value = id;
                daByKostentraeger.SelectCommand.Parameters[1].Value = IDKlinik;
                DataBase.Fill(daByKostentraeger, ds.PatientEinkommen);
            }

            return ds.PatientEinkommen;
        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPatientEinkommen));
            this.daPatientEinkommen = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPatienten = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daPatientEinkommenByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.daTransferKostentraeger = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            this.daByKostentraeger = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand10 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand12 = new System.Data.OleDb.OleDbCommand();
            this.daAllEntries = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand9 = new System.Data.OleDb.OleDbCommand();
            // 
            // daPatientEinkommen
            // 
            this.daPatientEinkommen.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPatientEinkommen.InsertCommand = this.oleDbInsertCommand1;
            this.daPatientEinkommen.SelectCommand = this.oleDbSelectCommand1;
            this.daPatientEinkommen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientEinkommen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("BetragVerwendbar", "BetragVerwendbar"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("TransferleistungJN", "TransferleistungJN"),
                        new System.Data.Common.DataColumnMapping("SelbstzahlerJN", "SelbstzahlerJN"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("IDBankliste", "IDBankliste"),
                        new System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"),
                        new System.Data.Common.DataColumnMapping("RechnungJN", "RechnungJN"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            this.daPatientEinkommen.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [PatientEinkommen] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("BetragVerwendbar", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "BetragVerwendbar", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 16, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("TransferleistungJN", System.Data.OleDb.OleDbType.Boolean, 0, "TransferleistungJN"),
            new System.Data.OleDb.OleDbParameter("SelbstzahlerJN", System.Data.OleDb.OleDbType.Boolean, 0, "SelbstzahlerJN"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.Date, 16, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.Date, 16, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger"),
            new System.Data.OleDb.OleDbParameter("IDBankliste", System.Data.OleDb.OleDbType.Guid, 0, "IDBankliste"),
            new System.Data.OleDb.OleDbParameter("Zahlart", System.Data.OleDb.OleDbType.Integer, 0, "Zahlart"),
            new System.Data.OleDb.OleDbParameter("RechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "RechnungJN"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("BetragVerwendbar", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "BetragVerwendbar", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 16, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("TransferleistungJN", System.Data.OleDb.OleDbType.Boolean, 0, "TransferleistungJN"),
            new System.Data.OleDb.OleDbParameter("SelbstzahlerJN", System.Data.OleDb.OleDbType.Boolean, 0, "SelbstzahlerJN"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.Date, 16, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.Date, 16, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger"),
            new System.Data.OleDb.OleDbParameter("IDBankliste", System.Data.OleDb.OleDbType.Guid, 0, "IDBankliste"),
            new System.Data.OleDb.OleDbParameter("Zahlart", System.Data.OleDb.OleDbType.Integer, 0, "Zahlart"),
            new System.Data.OleDb.OleDbParameter("RechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "RechnungJN"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatienten
            // 
            this.daPatienten.SelectCommand = this.oleDbCommand3;
            this.daPatienten.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientEinkommen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("BetragVerwendbar", "BetragVerwendbar"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("TransferleistungJN", "TransferleistungJN"),
                        new System.Data.Common.DataColumnMapping("SelbstzahlerJN", "SelbstzahlerJN"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("IDBankliste", "IDBankliste"),
                        new System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"),
                        new System.Data.Common.DataColumnMapping("RechnungJN", "RechnungJN"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 8, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // daPatientEinkommenByID
            // 
            this.daPatientEinkommenByID.DeleteCommand = this.oleDbCommand1;
            this.daPatientEinkommenByID.SelectCommand = this.oleDbCommand4;
            this.daPatientEinkommenByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientEinkommen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("BetragVerwendbar", "BetragVerwendbar"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("TransferleistungJN", "TransferleistungJN"),
                        new System.Data.Common.DataColumnMapping("SelbstzahlerJN", "SelbstzahlerJN"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("IDBankliste", "IDBankliste"),
                        new System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"),
                        new System.Data.Common.DataColumnMapping("RechnungJN", "RechnungJN"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            this.daPatientEinkommenByID.UpdateCommand = this.oleDbCommand5;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [PatientEinkommen] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
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
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("BetragVerwendbar", System.Data.OleDb.OleDbType.Double, 0, "BetragVerwendbar"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 16, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("TransferleistungJN", System.Data.OleDb.OleDbType.Boolean, 0, "TransferleistungJN"),
            new System.Data.OleDb.OleDbParameter("SelbstzahlerJN", System.Data.OleDb.OleDbType.Boolean, 0, "SelbstzahlerJN"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.Date, 16, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.Date, 16, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger"),
            new System.Data.OleDb.OleDbParameter("IDBankliste", System.Data.OleDb.OleDbType.Guid, 0, "IDBankliste"),
            new System.Data.OleDb.OleDbParameter("Zahlart", System.Data.OleDb.OleDbType.Integer, 0, "Zahlart"),
            new System.Data.OleDb.OleDbParameter("RechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "RechnungJN"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daTransferKostentraeger
            // 
            this.daTransferKostentraeger.SelectCommand = this.oleDbCommand8;
            this.daTransferKostentraeger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientEinkommen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("BetragVerwendbar", "BetragVerwendbar"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("TransferleistungJN", "TransferleistungJN"),
                        new System.Data.Common.DataColumnMapping("SelbstzahlerJN", "SelbstzahlerJN"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("IDBankliste", "IDBankliste"),
                        new System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"),
                        new System.Data.Common.DataColumnMapping("RechnungJN", "RechnungJN"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = resources.GetString("oleDbCommand8.CommandText");
            this.oleDbCommand8.Connection = this.oleDbConnection1;
            this.oleDbCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // daByKostentraeger
            // 
            this.daByKostentraeger.DeleteCommand = this.oleDbCommand10;
            this.daByKostentraeger.SelectCommand = this.oleDbCommand12;
            this.daByKostentraeger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientEinkommen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("BetragVerwendbar", "BetragVerwendbar"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("TransferleistungJN", "TransferleistungJN"),
                        new System.Data.Common.DataColumnMapping("SelbstzahlerJN", "SelbstzahlerJN"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("IDBankliste", "IDBankliste"),
                        new System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"),
                        new System.Data.Common.DataColumnMapping("RechnungJN", "RechnungJN"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            // 
            // oleDbCommand10
            // 
            this.oleDbCommand10.CommandText = "DELETE FROM [PatientEinkommen] WHERE (([ID] = ?))";
            this.oleDbCommand10.Connection = this.oleDbConnection1;
            this.oleDbCommand10.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand12
            // 
            this.oleDbCommand12.CommandText = resources.GetString("oleDbCommand12.CommandText");
            this.oleDbCommand12.Connection = this.oleDbConnection1;
            this.oleDbCommand12.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 16, "IDKostentraeger"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // daAllEntries
            // 
            this.daAllEntries.SelectCommand = this.oleDbCommand9;
            this.daAllEntries.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientEinkommen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("BetragVerwendbar", "BetragVerwendbar"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("TransferleistungJN", "TransferleistungJN"),
                        new System.Data.Common.DataColumnMapping("SelbstzahlerJN", "SelbstzahlerJN"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("IDBankliste", "IDBankliste"),
                        new System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"),
                        new System.Data.Common.DataColumnMapping("RechnungJN", "RechnungJN"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            // 
            // oleDbCommand9
            // 
            this.oleDbCommand9.CommandText = resources.GetString("oleDbCommand9.CommandText");
            this.oleDbCommand9.Connection = this.oleDbConnection1;
            this.oleDbCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});

		}
		#endregion
	}
}
