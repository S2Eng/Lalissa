//----------------------------------------------------------------------------------------------
//	DBPDx.cs
//  Zugriffsfunktionen auf die DB für die Pflegedefinition
//  Erstellt am:	13.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using PMDS.Global;using PMDS.Data.PflegePlan;
using RBU;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB
{
	/// <summary>
	/// Summary description for DBPDx.
	/// </summary>
	public class DBPDxEintrag : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daPDxEintrag;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private  dsPDxEintrag dsPDxEintrag1;
        private OleDbDataAdapter daPDxEintragNichtEntfernte;
        private OleDbCommand oleDbCommand1;
        private OleDbCommand oleDbCommand2;
        private OleDbCommand oleDbCommand4;
        private OleDbCommand oleDbCommand5;
		
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="container"></param>
		//----------------------------------------------------------------------------------------------
		public DBPDxEintrag(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public DBPDxEintrag()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Speichert die Zugeordneten einträge in die Db nach der Delete Insert Methode
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public void UpdatePDXEintragZuordnung(Guid[] aIDEintrag, Guid IDAbteilung, Guid IDPDx) 
		{
			Read(IDPDx, IDAbteilung);
			DeleteAll();
			dsPDxEintrag1.Clear();
			foreach(Guid g in aIDEintrag)				// Jede übergebene Zuordnung als neuen DS apeichern
			{
				dsPDxEintrag.PDXEintragRow r = dsPDxEintrag1.PDXEintrag.NewPDXEintragRow();
				r.ID		= Guid.NewGuid();
				r.IDAbteilung	= IDAbteilung;
				r.IDEintrag		= g;
				r.IDPDX			= IDPDx;
				dsPDxEintrag1.PDXEintrag.AddPDXEintragRow(r);
			}
			DataBase.Update(daPDxEintrag, dsPDxEintrag1);
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Löscht alle eingelesenen Einträge aus der DB
		/// </summary>
		//----------------------------------------------------------------------------------------------
		private void DeleteAll() 
		{
			foreach(dsPDxEintrag.PDXEintragRow r in DBUtil.CurrentRows(dsPDxEintrag1.PDXEintrag)) 
			{
				r.Delete();
			}
			DataBase.Update(daPDxEintrag, dsPDxEintrag1);
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liest die Zugeordneten Einträge zu einer bestimmten PDX/Abteilungs Kombination
        /// bReadEntfernte = true: Alle Einträge werden gelesen
        /// bReadEntfernte = false: Nur nicht entfernte Einträge werden gelesen
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public void Read(Guid IDPDx, Guid IDAbteilung, bool bReadEntfernte) 
		{
			dsPDxEintrag1.Clear();

            if (bReadEntfernte) //Alle
            {
                daPDxEintrag.SelectCommand.Parameters[0].Value = IDPDx;
                daPDxEintrag.SelectCommand.Parameters[1].Value = IDAbteilung;
                DataBase.Fill(daPDxEintrag, dsPDxEintrag1);
            }
            else //Nur nicht entfernte
            {
                daPDxEintragNichtEntfernte.SelectCommand.Parameters[0].Value = IDPDx;
                daPDxEintragNichtEntfernte.SelectCommand.Parameters[1].Value = IDAbteilung;
                DataBase.Fill(daPDxEintragNichtEntfernte, dsPDxEintrag1);
            }
		}

        //----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liest die Zugeordneten Einträge zu einer bestimmten PDX/Abteilungs Kombination
		/// </summary>
		//----------------------------------------------------------------------------------------------
        public void Read(Guid IDPDx, Guid IDAbteilung)
        {
            Read(IDPDx, IDAbteilung, true);
        }

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Einträge als Datatable
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public dsPDxEintrag.PDXEintragDataTable PDXEINTRAG 
		{
			get 
			{
				return dsPDxEintrag1.PDXEintrag;
			}
		}

        //Neu Nach 15.05.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Speichert die Zuordnungen in der DB
        /// </summary>
        //----------------------------------------------------------------------------
        public void InsertPDXEintragZuordnung(Guid aIDEintrag, Guid[] IDAbteilungen, Guid IDPDx)
        {
            dsPDxEintrag ds = new dsPDxEintrag();
            
            foreach (Guid g in IDAbteilungen)				// Jede übergebene Zuordnung als neuen DS apeichern
            {
                if (!ExistPDxEintrag(IDPDx, aIDEintrag, g))
                {
                    dsPDxEintrag.PDXEintragRow r = ds.PDXEintrag.NewPDXEintragRow();
                    r.ID = Guid.NewGuid();
                    r.IDAbteilung = g;
                    r.IDEintrag = aIDEintrag;
                    r.IDPDX = IDPDx;
                    ds.PDXEintrag.AddPDXEintragRow(r);
                }
            }
            DataBase.Update(daPDxEintrag, ds);
        }

        //Neu nach 15.05.2007 MDA
        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Liefert Eintrag mit zugehörigen gefundenen ID
        /// </summary>
        //----------------------------------------------------------------------------------------------
        public bool ExistPDxEintrag(Guid IDPDx, Guid IDEintrag, Guid IDAbteilung)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT * FROM PDXEintrag WHERE IDPDX = ? and IDEintrag=? and IDAbteilung=?";
                cmd.Parameters.AddWithValue("IDPDX", IDPDx);
                cmd.Parameters.AddWithValue("IDEintrag", IDEintrag);
                cmd.Parameters.AddWithValue("IDAbteilung", IDAbteilung);

                bool exist = false;
                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    System.Data.DataRow r = dtSelect.Rows[0];
                    exist = true;
                }

                return exist;

            }
            catch (Exception ex)
            {
                throw new Exception("ExistPDxEintrag: " + ex.ToString());
            }
        }


		
		//----------------------------------------------------------------------------------------------
		/// <summary> 
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------------------------
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPDxEintrag));
            this.daPDxEintrag = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsPDxEintrag1 = new dsPDxEintrag();
            this.daPDxEintragNichtEntfernte = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintrag1)).BeginInit();
            // 
            // daPDxEintrag
            // 
            this.daPDxEintrag.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPDxEintrag.InsertCommand = this.oleDbInsertCommand1;
            this.daPDxEintrag.SelectCommand = this.oleDbSelectCommand1;
            this.daPDxEintrag.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDXEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung")})});
            this.daPDxEintrag.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM PDXEintrag WHERE (ID = ?)";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO PDXEintrag(ID, IDPDX, IDEintrag, IDAbteilung) VALUES (?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE PDXEintrag SET ID = ?, IDPDX = ?, IDEintrag = ?, IDAbteilung = ? WHERE (ID" +
                " = ?)";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsPDxEintrag1
            // 
            this.dsPDxEintrag1.DataSetName = "dsPDxEintrag";
            this.dsPDxEintrag1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDxEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daPDxEintragNichtEntfernte
            // 
            this.daPDxEintragNichtEntfernte.DeleteCommand = this.oleDbCommand1;
            this.daPDxEintragNichtEntfernte.InsertCommand = this.oleDbCommand2;
            this.daPDxEintragNichtEntfernte.SelectCommand = this.oleDbCommand4;
            this.daPDxEintragNichtEntfernte.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDXEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung")})});
            this.daPDxEintragNichtEntfernte.UpdateCommand = this.oleDbCommand5;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM PDXEintrag WHERE (ID = ?)";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "INSERT INTO PDXEintrag(ID, IDPDX, IDEintrag, IDAbteilung) VALUES (?, ?, ?, ?)";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = "UPDATE PDXEintrag SET ID = ?, IDPDX = ?, IDEintrag = ?, IDAbteilung = ? WHERE (ID" +
                " = ?)";
            this.oleDbCommand5.Connection = this.oleDbConnection1;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintrag1)).EndInit();

		}
		#endregion
	}
}
