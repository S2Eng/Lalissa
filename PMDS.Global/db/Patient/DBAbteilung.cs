//----------------------------------------------------------------------------------------------
//	DBAbteilung.cs
//  Zugriffsfunktionen auf die Abteilung
//  Erstellt am:	16.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using RBU;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;




namespace PMDS.DB
{
	/// <summary>
	/// Summary description for DBAbteilung.
	/// </summary>
	public class DBAbteilung : System.ComponentModel.Component
	{
		private dsAbteilung dsAbteilungListe1;				// Abteilungsliste
		private System.Data.OleDb.OleDbDataAdapter daAbteilungListe;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbConnection oleDbConnection2;
        private System.Data.OleDb.OleDbDataAdapter daAbteilungBezeichnung;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbDataAdapter daBereichBezeichnung;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        public System.Data.OleDb.OleDbDataAdapter daAbteilungenByKlinik;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        public System.Data.OleDb.OleDbDataAdapter daAbteilung2ByKlinik;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
        public System.Data.OleDb.OleDbDataAdapter daBereicheByIDAbteilung;
        private System.Data.OleDb.OleDbCommand oleDbCommand5;
        private System.Data.OleDb.OleDbCommand oleDbCommand6;
        private System.Data.OleDb.OleDbCommand oleDbCommand7;
        private System.Data.OleDb.OleDbCommand oleDbCommand8;
        private System.ComponentModel.Container components = null;
        
		public DBAbteilung(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}





		public dsAbteilung.AbteilungDataTable	ABTEILUNGLISTE 
		{
			get 
			{
				if(dsAbteilungListe1 == null) 
					dsAbteilungListe1 = new dsAbteilung();

				FillAbteilungsListe();
				return dsAbteilungListe1.Abteilung;
			}
		}
        
		private void FillAbteilungsListe() 
		{
			dsAbteilungListe1.Clear();
			DataBase.Fill( daAbteilungListe, dsAbteilungListe1);
    	}

        public bool getAbteilungenByKlinik(System.Guid IDKlinik, dsAbteilung dsAbteilung1)
        {
            dsAbteilung1.Clear();
            this.daAbteilungenByKlinik.SelectCommand.Parameters[0].Value = IDKlinik;
            DataBase.Fill(this.daAbteilungenByKlinik, dsAbteilung1);
            return true;
        }
        public bool getAbteilungenByKlinik2(System.Guid IDKlinik, dsAbteilung dsAbteilung1)
        {
            dsAbteilung1.Clear();
            this.daAbteilung2ByKlinik.SelectCommand.Parameters[0].Value = IDKlinik;
            DataBase.Fill(this.daAbteilung2ByKlinik, dsAbteilung1.Abteilung2);
            return true;
        }
        public bool getBereicheByAbteilung(System.Guid IDAbteilung, dsAbteilung dsAbteilung1)
        {
            dsAbteilung1.Clear();
            this.daBereicheByIDAbteilung.SelectCommand.Parameters[0].Value = IDAbteilung;
            DataBase.Fill(this.daBereicheByIDAbteilung, dsAbteilung1.Bereich);
            return true;
        }
        public dsAbteilung.Abteilung2Row getNewRowAbteilung(dsAbteilung ds)
        {
            try
            {
                dsAbteilung.Abteilung2Row rNew = (dsAbteilung.Abteilung2Row)ds.Abteilung2.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.Bezeichnung = "";
                rNew.IDKlinik = System.Guid.NewGuid();
                rNew.SetIDKontaktNull();
                rNew.RMOptionalJN = false;
                rNew.Reihenfolge = -1;
                rNew.Basisabteilung = false;

                ds.Abteilung2.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("getNewRowAbteilung: " + ex.ToString());
            }
        }
        public dsAbteilung.BereichRow getNewRowBereich(dsAbteilung ds)
        {
            try
            {
                dsAbteilung.BereichRow rNew = (dsAbteilung.BereichRow)ds.Bereich.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.IDAbteilung = System.Guid.NewGuid();
                rNew.SetIDBereichNull();
                rNew.Bezeichnung = "";
                rNew.UnterAerztlicheFuehrungJN = false;
                rNew.Reihenfolge = -1;

                ds.Bereich.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("getNewRowBereich: " + ex.ToString());
            }
        }
        public string  getAbteilungBez (Guid idAbteilung)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            daAbteilungBezeichnung.SelectCommand.Parameters[0].Value = idAbteilung;
            DataBase.Fill(daAbteilungBezeichnung, dt);
            if (dt.Rows.Count >= 1)
            {
                return dt.Rows[0]["Bezeichnung"].ToString();
            }
            else
            {
                return "";
            }
        }
        public string getBereichBez(Guid idBereich)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            this.daBereichBezeichnung .SelectCommand.Parameters[0].Value = idBereich;
            DataBase.Fill(daBereichBezeichnung, dt);
            if (dt.Rows.Count >= 1)
            {
                return  dt.Rows[0]["Bezeichnung"].ToString ();
            }
            else
            {
                return "";
            }
        }
		/// <summary>
		/// Liest die Einträge neu
		/// </summary>
		public void RefreshAbteilungsListe() 
		{
			FillAbteilungsListe();
		}

		public DBAbteilung()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Dispose
		/// </summary>
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
            this.daAbteilungListe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbConnection2 = new System.Data.OleDb.OleDbConnection();
            this.daAbteilungBezeichnung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daBereichBezeichnung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daAbteilungenByKlinik = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daAbteilung2ByKlinik = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.daBereicheByIDAbteilung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            // 
            // daAbteilungListe
            // 
            this.daAbteilungListe.SelectCommand = this.oleDbSelectCommand1;
            this.daAbteilungListe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("Basisabteilung", "Basisabteilung")})});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT        ID, IDKlinik, Bezeichnung, IDKontakt, RMOptionalJN, Reihenfolge, Ba" +
    "sisabteilung\r\nFROM            Abteilung\r\nORDER BY Reihenfolge, Bezeichnung";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection2;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=stysrv02v\\sql2012;Integrated Security=SSPI;Initial" +
    " Catalog=PMDSDev";
            // 
            // oleDbConnection2
            // 
            this.oleDbConnection2.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // daAbteilungBezeichnung
            // 
            this.daAbteilungBezeichnung.SelectCommand = this.oleDbCommand1;
            this.daAbteilungBezeichnung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "SELECT        Bezeichnung\r\nFROM            Abteilung \r\nWHERE        (ID = ?)";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daBereichBezeichnung
            // 
            this.daBereichBezeichnung.SelectCommand = this.oleDbCommand2;
            this.daBereichBezeichnung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Bereich", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "SELECT        Bezeichnung\r\nFROM            Bereich \r\nWHERE        (ID = ?)";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daAbteilungenByKlinik
            // 
            this.daAbteilungenByKlinik.SelectCommand = this.oleDbCommand3;
            this.daAbteilungenByKlinik.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("Basisabteilung", "Basisabteilung")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT        ID, IDKlinik, Bezeichnung, IDKontakt, RMOptionalJN, Reihenfolge, Ba" +
    "sisabteilung\r\nFROM            Abteilung\r\nWHERE        (IDKlinik = ?)\r\nORDER BY R" +
    "eihenfolge, Bezeichnung";
            this.oleDbCommand3.Connection = this.oleDbConnection2;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // daAbteilung2ByKlinik
            // 
            this.daAbteilung2ByKlinik.DeleteCommand = this.oleDbDeleteCommand;
            this.daAbteilung2ByKlinik.InsertCommand = this.oleDbInsertCommand;
            this.daAbteilung2ByKlinik.SelectCommand = this.oleDbCommand4;
            this.daAbteilung2ByKlinik.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("Basisabteilung", "Basisabteilung")})});
            this.daAbteilung2ByKlinik.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [Abteilung] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = this.oleDbConnection2;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = "INSERT INTO [Abteilung] ([ID], [IDKlinik], [Bezeichnung], [IDKontakt], [RMOptiona" +
    "lJN], [Reihenfolge], [Basisabteilung]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand.Connection = this.oleDbConnection2;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "RMOptionalJN"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Basisabteilung", System.Data.OleDb.OleDbType.Boolean, 0, "Basisabteilung")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "SELECT        ID, IDKlinik, Bezeichnung, IDKontakt, RMOptionalJN, Reihenfolge, Ba" +
    "sisabteilung\r\nFROM            Abteilung\r\nWHERE        (IDKlinik = ?)\r\nORDER BY R" +
    "eihenfolge, Bezeichnung";
            this.oleDbCommand4.Connection = this.oleDbConnection2;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = "UPDATE [Abteilung] SET [ID] = ?, [IDKlinik] = ?, [Bezeichnung] = ?, [IDKontakt] =" +
    " ?, [RMOptionalJN] = ?, [Reihenfolge] = ?, [Basisabteilung] = ? WHERE (([ID] = ?" +
    "))";
            this.oleDbUpdateCommand.Connection = this.oleDbConnection2;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "RMOptionalJN"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Basisabteilung", System.Data.OleDb.OleDbType.Boolean, 0, "Basisabteilung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daBereicheByIDAbteilung
            // 
            this.daBereicheByIDAbteilung.DeleteCommand = this.oleDbCommand5;
            this.daBereicheByIDAbteilung.InsertCommand = this.oleDbCommand6;
            this.daBereicheByIDAbteilung.SelectCommand = this.oleDbCommand7;
            this.daBereicheByIDAbteilung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Bereich", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("UnterAerztlicheFuehrungJN", "UnterAerztlicheFuehrungJN"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge")})});
            this.daBereicheByIDAbteilung.UpdateCommand = this.oleDbCommand8;
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = "DELETE FROM [dbo].[Bereich] WHERE (([ID] = ?))";
            this.oleDbCommand5.Connection = this.oleDbConnection1;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand6
            // 
            this.oleDbCommand6.CommandText = "INSERT INTO [dbo].[Bereich] ([ID], [IDAbteilung], [IDBereich], [Bezeichnung], [Un" +
    "terAerztlicheFuehrungJN], [Reihenfolge]) VALUES (?, ?, ?, ?, ?, ?)";
            this.oleDbCommand6.Connection = this.oleDbConnection1;
            this.oleDbCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("UnterAerztlicheFuehrungJN", System.Data.OleDb.OleDbType.Boolean, 0, "UnterAerztlicheFuehrungJN"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge")});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = "SELECT        ID, IDAbteilung, IDBereich, Bezeichnung, UnterAerztlicheFuehrungJN," +
    " Reihenfolge\r\nFROM            Bereich\r\nWHERE        (IDAbteilung = ?)\r\nORDER BY " +
    "Bezeichnung";
            this.oleDbCommand7.Connection = this.oleDbConnection1;
            this.oleDbCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = "UPDATE [dbo].[Bereich] SET [ID] = ?, [IDAbteilung] = ?, [IDBereich] = ?, [Bezeich" +
    "nung] = ?, [UnterAerztlicheFuehrungJN] = ?, [Reihenfolge] = ? WHERE (([ID] = ?))" +
    "";
            this.oleDbCommand8.Connection = this.oleDbConnection1;
            this.oleDbCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("UnterAerztlicheFuehrungJN", System.Data.OleDb.OleDbType.Boolean, 0, "UnterAerztlicheFuehrungJN"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});

		}
		#endregion
	}
}
