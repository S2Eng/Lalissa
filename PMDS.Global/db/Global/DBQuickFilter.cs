using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using PMDS.Global;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;




namespace PMDS.DB
{


	public class DBQuickFilter : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private PMDS.Global.db.Global.dsQuickFilter dsQuickFilter1;
		private System.Data.OleDb.OleDbDataAdapter daQuickFilterOne;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private System.Data.OleDb.OleDbDataAdapter daQuickFilterAbteilung;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
        public System.Data.OleDb.OleDbDataAdapter daQuickFilterAll;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
        private System.ComponentModel.Container components = null;






		public DBQuickFilter(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		public DBQuickFilter()
		{
			InitializeComponent();
		}

        public dsQuickFilter.QuickFilterDataTable ReadAll(Guid IDAbteilung, Guid IDKlinik)
		{
			dsQuickFilter.QuickFilterDataTable dt = new dsQuickFilter.QuickFilterDataTable();
            string sql = daQuickFilterAll.SelectCommand.CommandText;

            //if (!IQuickNurAbt) sql += " or (IDAbteilung LIKE '00000%') ";
            //sql += " and (IDAbteilung='" + IDAbteilung.ToString() + "') ";
            //if (!IQuickNurAbt) sql += " or (IDAbteilung='" + IDAbteilung.ToString() + "') ";

            sql += " WHERE (IDAbteilung IN (SELECT Abteilung.ID " +
                                       " FROM Abteilung INNER JOIN " +
                                       " Klinik ON Abteilung.IDKlinik = Klinik.ID " +
                                       " WHERE Abteilung.Basisabteilung=1 and (Klinik.ID='" + IDKlinik.ToString() + "'))) ";

            if (IDAbteilung != System.Guid.Empty)
            {
                sql += " or (IDAbteilung IN (SELECT Abteilung.ID " +
                                           " FROM Abteilung INNER JOIN " +
                                           " Klinik ON Abteilung.IDKlinik = Klinik.ID " +
                                           " WHERE Abteilung.Basisabteilung=0 and Abteilung.ID='" + IDAbteilung.ToString() + "' and (Klinik.ID='" + IDKlinik.ToString() + "'))) ";
            }

            sql += " ORDER BY Bezeichnung DESC ";
            sql = sql.Replace("{parID}", "'" + IDKlinik.ToString() + "'");
            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter( );
            System.Data.OleDb.OleDbCommand selCmd = new System.Data.OleDb.OleDbCommand(sql);
            //selCmd.Parameters.Add("@ID", System.Data .OleDb.OleDbType.Guid).Value = IDKlinik;
            da.SelectCommand = selCmd;
            DataBase.Fill(da, dt);
			return dt;
		}

        public bool UpdateLayout(Guid IDQuickfilter, string KeyQuickfilter)
        {
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "Update QuickFilter set KeyLayout = '" + KeyQuickfilter.Trim() + "' where ID = '" + IDQuickfilter .ToString() + "'";
            DataBase.EcecuteNonQuery(cmd);
            return true;
        }

        public static string getLayoutKeyForQuickFilterxyxy(Guid IDQuickfilter, string KeyQuickfilter, Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            string IDResReturnGrid = KeyQuickfilter.Trim() + "_" + grid.Name.ToString(); ;
            string IDResDescriptionGrid = "";
            //QS2.Desktop.ControlManagment.ControlManagment.getIDREsForControl(grid, ref IDResReturnGrid, ref IDResDescriptionGrid);
            string KeyReturn = KeyQuickfilter.Trim() + "_" + IDResReturnGrid.Trim();
            return KeyReturn;
        }

        public dsQuickFilter.QuickFilterDataTable ReadAllNurGesHaus(Guid IDKlinik)
        {
            dsQuickFilter.QuickFilterDataTable dt = new dsQuickFilter.QuickFilterDataTable();
            string sql = daQuickFilterAll.SelectCommand.CommandText;
            sql += " WHERE (IDAbteilung IN (SELECT Abteilung.ID " +
                               " FROM Abteilung INNER JOIN " +
                               " Klinik ON Abteilung.IDKlinik = Klinik.ID " +
                               " WHERE (Klinik.ID='" + IDKlinik.ToString() + "'))) ";
            //sql += " and (IDAbteilung='" + System.Guid.Empty.ToString() + "') ";
            //sql += " and (IDAbteilung LIKE '00000%') ";
            sql += " ORDER BY Bezeichnung DESC ";
            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
            System.Data.OleDb.OleDbCommand selCmd = new System.Data.OleDb.OleDbCommand(sql);
            da.SelectCommand = selCmd;
            DataBase.Fill(da, dt);
            return dt;
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle Filter in der DB: Alle der generellen Abteilung und 
		/// alle der übergebenen Abteilung
		/// </summary>
		//----------------------------------------------------------------------------
		public dsQuickFilter.QuickFilterSmallDataTable ReadAllAbteilung(Guid IDAbteilung)
		{
            dsQuickFilter.QuickFilterSmallDataTable dt = new dsQuickFilter.QuickFilterSmallDataTable();
			daQuickFilterAbteilung.SelectCommand.Parameters[0].Value = IDAbteilung;
			DataBase.Fill(daQuickFilterAbteilung, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert einen einzelnen
		/// </summary>
		//----------------------------------------------------------------------------
		public dsQuickFilter.QuickFilterDataTable Read(Guid ID)
		{
			dsQuickFilter.QuickFilterDataTable dt = new dsQuickFilter.QuickFilterDataTable();
			daQuickFilterOne.SelectCommand.Parameters[0].Value = ID;
			DataBase.Fill(daQuickFilterOne, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Ab in die DB
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write(dsQuickFilter.QuickFilterDataTable dt)
		{
			DataBase.Update(daQuickFilterAll, dt); 
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBQuickFilter));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daQuickFilterOne = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daQuickFilterAbteilung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.dsQuickFilter1 = new PMDS.Global.db.Global.dsQuickFilter();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daQuickFilterAll = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsQuickFilter1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // daQuickFilterOne
            // 
            this.daQuickFilterOne.SelectCommand = this.oleDbSelectCommand2;
            this.daQuickFilterOne.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuickFilter", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("MassnahmeJN", "MassnahmeJN"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("BezugspersonJN", "BezugspersonJN"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("ZeitraumJN", "ZeitraumJN"),
                        new System.Data.Common.DataColumnMapping("Tagevorher", "Tagevorher"),
                        new System.Data.Common.DataColumnMapping("Tagenachher", "Tagenachher"),
                        new System.Data.Common.DataColumnMapping("RueckgemeldeteTermineJN", "RueckgemeldeteTermineJN"),
                        new System.Data.Common.DataColumnMapping("AbwBerufstandJN", "AbwBerufstandJN"),
                        new System.Data.Common.DataColumnMapping("Massnahmen", "Massnahmen"),
                        new System.Data.Common.DataColumnMapping("TypJN", "TypJN"),
                        new System.Data.Common.DataColumnMapping("EintragTyp", "EintragTyp"),
                        new System.Data.Common.DataColumnMapping("Tooltip", "Tooltip"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("BenutzenInInterventionJN", "BenutzenInInterventionJN"),
                        new System.Data.Common.DataColumnMapping("BenutzenInEvaluierungJN", "BenutzenInEvaluierungJN"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("KeyLayout", "KeyLayout"),
                        new System.Data.Common.DataColumnMapping("KeyQuickFilter", "KeyQuickFilter"),
                        new System.Data.Common.DataColumnMapping("BereichIntervention", "BereichIntervention"),
                        new System.Data.Common.DataColumnMapping("BereichÜbergabe", "BereichÜbergabe"),
                        new System.Data.Common.DataColumnMapping("BenutzenInDekursJN", "BenutzenInDekursJN"),
                        new System.Data.Common.DataColumnMapping("BereichDekurs", "BereichDekurs"),
                        new System.Data.Common.DataColumnMapping("LstErstelltVonBerufgruppe", "LstErstelltVonBerufgruppe"),
                        new System.Data.Common.DataColumnMapping("LstWichtigFürBerufsgruppe", "LstWichtigFürBerufsgruppe"),
                        new System.Data.Common.DataColumnMapping("ShowCC", "ShowCC"),
                        new System.Data.Common.DataColumnMapping("LstZusatzwerte", "LstZusatzwerte"),
                        new System.Data.Common.DataColumnMapping("LstZeitbezug", "LstZeitbezug"),
                        new System.Data.Common.DataColumnMapping("LstHerkunftPlanungsEintrag", "LstHerkunftPlanungsEintrag"),
                        new System.Data.Common.DataColumnMapping("LstInterventionsTyp", "LstInterventionsTyp"),
                        new System.Data.Common.DataColumnMapping("AbzeichnenJN", "AbzeichnenJN"),
                        new System.Data.Common.DataColumnMapping("IsStandard", "IsStandard"),
                        new System.Data.Common.DataColumnMapping("LstBSQuickfilter", "LstBSQuickfilter")})});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daQuickFilterAbteilung
            // 
            this.daQuickFilterAbteilung.SelectCommand = this.oleDbCommand3;
            this.daQuickFilterAbteilung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuickFilter", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("BenutzenInInterventionJN", "BenutzenInInterventionJN"),
                        new System.Data.Common.DataColumnMapping("BenutzenInEvaluierungJN", "BenutzenInEvaluierungJN"),
                        new System.Data.Common.DataColumnMapping("BenutzenInDekursJN", "BenutzenInDekursJN"),
                        new System.Data.Common.DataColumnMapping("BereichIntervention", "BereichIntervention"),
                        new System.Data.Common.DataColumnMapping("BereichÜbergabe", "BereichÜbergabe"),
                        new System.Data.Common.DataColumnMapping("BereichDekurs", "BereichDekurs"),
                        new System.Data.Common.DataColumnMapping("KeyQuickFilter", "KeyQuickFilter")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // dsQuickFilter1
            // 
            this.dsQuickFilter1.DataSetName = "dsQuickFilter";
            this.dsQuickFilter1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsQuickFilter1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            // 
            // daQuickFilterAll
            // 
            this.daQuickFilterAll.DeleteCommand = this.oleDbDeleteCommand;
            this.daQuickFilterAll.InsertCommand = this.oleDbInsertCommand;
            this.daQuickFilterAll.SelectCommand = this.oleDbSelectCommand3;
            this.daQuickFilterAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuickFilter", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("MassnahmeJN", "MassnahmeJN"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("BezugspersonJN", "BezugspersonJN"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("ZeitraumJN", "ZeitraumJN"),
                        new System.Data.Common.DataColumnMapping("Tagevorher", "Tagevorher"),
                        new System.Data.Common.DataColumnMapping("Tagenachher", "Tagenachher"),
                        new System.Data.Common.DataColumnMapping("RueckgemeldeteTermineJN", "RueckgemeldeteTermineJN"),
                        new System.Data.Common.DataColumnMapping("AbwBerufstandJN", "AbwBerufstandJN"),
                        new System.Data.Common.DataColumnMapping("Massnahmen", "Massnahmen"),
                        new System.Data.Common.DataColumnMapping("TypJN", "TypJN"),
                        new System.Data.Common.DataColumnMapping("EintragTyp", "EintragTyp"),
                        new System.Data.Common.DataColumnMapping("Tooltip", "Tooltip"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("BenutzenInInterventionJN", "BenutzenInInterventionJN"),
                        new System.Data.Common.DataColumnMapping("BenutzenInEvaluierungJN", "BenutzenInEvaluierungJN"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("KeyLayout", "KeyLayout"),
                        new System.Data.Common.DataColumnMapping("KeyQuickFilter", "KeyQuickFilter"),
                        new System.Data.Common.DataColumnMapping("BereichIntervention", "BereichIntervention"),
                        new System.Data.Common.DataColumnMapping("BereichÜbergabe", "BereichÜbergabe"),
                        new System.Data.Common.DataColumnMapping("BenutzenInDekursJN", "BenutzenInDekursJN"),
                        new System.Data.Common.DataColumnMapping("BereichDekurs", "BereichDekurs"),
                        new System.Data.Common.DataColumnMapping("LstErstelltVonBerufgruppe", "LstErstelltVonBerufgruppe"),
                        new System.Data.Common.DataColumnMapping("LstWichtigFürBerufsgruppe", "LstWichtigFürBerufsgruppe"),
                        new System.Data.Common.DataColumnMapping("ShowCC", "ShowCC"),
                        new System.Data.Common.DataColumnMapping("LstZusatzwerte", "LstZusatzwerte"),
                        new System.Data.Common.DataColumnMapping("LstZeitbezug", "LstZeitbezug"),
                        new System.Data.Common.DataColumnMapping("LstHerkunftPlanungsEintrag", "LstHerkunftPlanungsEintrag"),
                        new System.Data.Common.DataColumnMapping("LstInterventionsTyp", "LstInterventionsTyp"),
                        new System.Data.Common.DataColumnMapping("AbzeichnenJN", "AbzeichnenJN"),
                        new System.Data.Common.DataColumnMapping("IsStandard", "IsStandard"),
                        new System.Data.Common.DataColumnMapping("LstBSQuickfilter", "LstBSQuickfilter")})});
            this.daQuickFilterAll.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = resources.GetString("oleDbInsertCommand.CommandText");
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("MassnahmeJN", System.Data.OleDb.OleDbType.Boolean, 0, "MassnahmeJN"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("BezugspersonJN", System.Data.OleDb.OleDbType.Boolean, 0, "BezugspersonJN"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("ZeitraumJN", System.Data.OleDb.OleDbType.Boolean, 0, "ZeitraumJN"),
            new System.Data.OleDb.OleDbParameter("Tagevorher", System.Data.OleDb.OleDbType.Integer, 0, "Tagevorher"),
            new System.Data.OleDb.OleDbParameter("Tagenachher", System.Data.OleDb.OleDbType.Integer, 0, "Tagenachher"),
            new System.Data.OleDb.OleDbParameter("RueckgemeldeteTermineJN", System.Data.OleDb.OleDbType.Boolean, 0, "RueckgemeldeteTermineJN"),
            new System.Data.OleDb.OleDbParameter("AbwBerufstandJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbwBerufstandJN"),
            new System.Data.OleDb.OleDbParameter("Massnahmen", System.Data.OleDb.OleDbType.VarChar, 0, "Massnahmen"),
            new System.Data.OleDb.OleDbParameter("TypJN", System.Data.OleDb.OleDbType.Boolean, 0, "TypJN"),
            new System.Data.OleDb.OleDbParameter("EintragTyp", System.Data.OleDb.OleDbType.Integer, 0, "EintragTyp"),
            new System.Data.OleDb.OleDbParameter("Tooltip", System.Data.OleDb.OleDbType.VarChar, 0, "Tooltip"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("BenutzenInInterventionJN", System.Data.OleDb.OleDbType.Boolean, 0, "BenutzenInInterventionJN"),
            new System.Data.OleDb.OleDbParameter("BenutzenInEvaluierungJN", System.Data.OleDb.OleDbType.Boolean, 0, "BenutzenInEvaluierungJN"),
            new System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.Integer, 0, "OhneZeitBezug"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("KeyLayout", System.Data.OleDb.OleDbType.VarWChar, 0, "KeyLayout"),
            new System.Data.OleDb.OleDbParameter("KeyQuickFilter", System.Data.OleDb.OleDbType.VarWChar, 0, "KeyQuickFilter"),
            new System.Data.OleDb.OleDbParameter("BereichIntervention", System.Data.OleDb.OleDbType.Boolean, 0, "BereichIntervention"),
            new System.Data.OleDb.OleDbParameter("BereichÜbergabe", System.Data.OleDb.OleDbType.Boolean, 0, "BereichÜbergabe"),
            new System.Data.OleDb.OleDbParameter("BenutzenInDekursJN", System.Data.OleDb.OleDbType.Boolean, 0, "BenutzenInDekursJN"),
            new System.Data.OleDb.OleDbParameter("BereichDekurs", System.Data.OleDb.OleDbType.Boolean, 0, "BereichDekurs"),
            new System.Data.OleDb.OleDbParameter("LstErstelltVonBerufgruppe", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstErstelltVonBerufgruppe"),
            new System.Data.OleDb.OleDbParameter("LstWichtigFürBerufsgruppe", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstWichtigFürBerufsgruppe"),
            new System.Data.OleDb.OleDbParameter("ShowCC", System.Data.OleDb.OleDbType.Integer, 0, "ShowCC"),
            new System.Data.OleDb.OleDbParameter("LstZusatzwerte", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstZusatzwerte"),
            new System.Data.OleDb.OleDbParameter("LstZeitbezug", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstZeitbezug"),
            new System.Data.OleDb.OleDbParameter("LstHerkunftPlanungsEintrag", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstHerkunftPlanungsEintrag"),
            new System.Data.OleDb.OleDbParameter("LstInterventionsTyp", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstInterventionsTyp"),
            new System.Data.OleDb.OleDbParameter("AbzeichnenJN", System.Data.OleDb.OleDbType.Integer, 0, "AbzeichnenJN"),
            new System.Data.OleDb.OleDbParameter("IsStandard", System.Data.OleDb.OleDbType.Boolean, 0, "IsStandard"),
            new System.Data.OleDb.OleDbParameter("LstBSQuickfilter", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstBSQuickfilter")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("MassnahmeJN", System.Data.OleDb.OleDbType.Boolean, 0, "MassnahmeJN"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("BezugspersonJN", System.Data.OleDb.OleDbType.Boolean, 0, "BezugspersonJN"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("ZeitraumJN", System.Data.OleDb.OleDbType.Boolean, 0, "ZeitraumJN"),
            new System.Data.OleDb.OleDbParameter("Tagevorher", System.Data.OleDb.OleDbType.Integer, 0, "Tagevorher"),
            new System.Data.OleDb.OleDbParameter("Tagenachher", System.Data.OleDb.OleDbType.Integer, 0, "Tagenachher"),
            new System.Data.OleDb.OleDbParameter("RueckgemeldeteTermineJN", System.Data.OleDb.OleDbType.Boolean, 0, "RueckgemeldeteTermineJN"),
            new System.Data.OleDb.OleDbParameter("AbwBerufstandJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbwBerufstandJN"),
            new System.Data.OleDb.OleDbParameter("Massnahmen", System.Data.OleDb.OleDbType.VarChar, 0, "Massnahmen"),
            new System.Data.OleDb.OleDbParameter("TypJN", System.Data.OleDb.OleDbType.Boolean, 0, "TypJN"),
            new System.Data.OleDb.OleDbParameter("EintragTyp", System.Data.OleDb.OleDbType.Integer, 0, "EintragTyp"),
            new System.Data.OleDb.OleDbParameter("Tooltip", System.Data.OleDb.OleDbType.VarChar, 0, "Tooltip"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("BenutzenInInterventionJN", System.Data.OleDb.OleDbType.Boolean, 0, "BenutzenInInterventionJN"),
            new System.Data.OleDb.OleDbParameter("BenutzenInEvaluierungJN", System.Data.OleDb.OleDbType.Boolean, 0, "BenutzenInEvaluierungJN"),
            new System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.Integer, 0, "OhneZeitBezug"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("KeyLayout", System.Data.OleDb.OleDbType.VarWChar, 0, "KeyLayout"),
            new System.Data.OleDb.OleDbParameter("KeyQuickFilter", System.Data.OleDb.OleDbType.VarWChar, 0, "KeyQuickFilter"),
            new System.Data.OleDb.OleDbParameter("BereichIntervention", System.Data.OleDb.OleDbType.Boolean, 0, "BereichIntervention"),
            new System.Data.OleDb.OleDbParameter("BereichÜbergabe", System.Data.OleDb.OleDbType.Boolean, 0, "BereichÜbergabe"),
            new System.Data.OleDb.OleDbParameter("BenutzenInDekursJN", System.Data.OleDb.OleDbType.Boolean, 0, "BenutzenInDekursJN"),
            new System.Data.OleDb.OleDbParameter("BereichDekurs", System.Data.OleDb.OleDbType.Boolean, 0, "BereichDekurs"),
            new System.Data.OleDb.OleDbParameter("LstErstelltVonBerufgruppe", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstErstelltVonBerufgruppe"),
            new System.Data.OleDb.OleDbParameter("LstWichtigFürBerufsgruppe", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstWichtigFürBerufsgruppe"),
            new System.Data.OleDb.OleDbParameter("ShowCC", System.Data.OleDb.OleDbType.Integer, 0, "ShowCC"),
            new System.Data.OleDb.OleDbParameter("LstZusatzwerte", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstZusatzwerte"),
            new System.Data.OleDb.OleDbParameter("LstZeitbezug", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstZeitbezug"),
            new System.Data.OleDb.OleDbParameter("LstHerkunftPlanungsEintrag", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstHerkunftPlanungsEintrag"),
            new System.Data.OleDb.OleDbParameter("LstInterventionsTyp", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstInterventionsTyp"),
            new System.Data.OleDb.OleDbParameter("AbzeichnenJN", System.Data.OleDb.OleDbType.Integer, 0, "AbzeichnenJN"),
            new System.Data.OleDb.OleDbParameter("IsStandard", System.Data.OleDb.OleDbType.Boolean, 0, "IsStandard"),
            new System.Data.OleDb.OleDbParameter("LstBSQuickfilter", System.Data.OleDb.OleDbType.LongVarWChar, 0, "LstBSQuickfilter"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [QuickFilter] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsQuickFilter1)).EndInit();

		}
		#endregion
	}
}
