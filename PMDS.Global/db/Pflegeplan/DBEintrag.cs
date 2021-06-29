//----------------------------------------------------------------------------------------------
//	DBAbteilungEintrag.cs
//  Zugriffsfunktionen auf die Kataloge von den A/S/Z/M 
//  Erstellt am:	14.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using RBU;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using System.Data.OleDb;
using System.Text;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB
{
	/// <summary>
	/// Summary description for DBAbteilungEintrag.
	/// </summary>
	public class DBEintrag : System.ComponentModel.Component
	{

		private char				_Group=' ';
        private System.Data.OleDb.OleDbDataAdapter daEintrag;
        private dsEintrag dsEintrag1;
		
		
		private System.Data.OleDb.OleDbDataAdapter daEintragAll;
        private System.Data.OleDb.OleDbDataAdapter daEintragQuery;
		private System.ComponentModel.Container components = null;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
        private OleDbCommand oleDbSelectCommand4;
        private OleDbDataAdapter daEintragOne;
        private dsPDx dsPDx1;
        private OleDbCommand oleDbSelectCommand5;
        private OleDbDataAdapter daPDxZuordnungen;
        private OleDbCommand oleDbDeleteCommand;
        private OleDbCommand oleDbInsertCommand;
        private OleDbCommand oleDbUpdateCommand;
        private string					_OriginalQuery;
        

        public static string GetText(Guid IDEintrag)
		{
			try 
			{
                return DBUtil.GetEintrag(IDEintrag).Text;
			}
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - DBEintrag::GetText()");
            }

		}

 
		public DBEintrag(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			_OriginalQuery = daEintragQuery.SelectCommand.CommandText;				// Merken
		}

		public DBEintrag()
		{
			InitializeComponent();
			_OriginalQuery = daEintragQuery.SelectCommand.CommandText;				// Merken
		}

		public void Read(char Group, bool Alle)
		{
			_Group = Group;
			dsEintrag1.Clear();
			if(_Group == 'X')									// Alle Einträge
			{
				DataBase.Fill(daEintragAll, dsEintrag1);
			}
			else												// nur die jeweilige Gruppe
			{
				daEintrag.SelectCommand.Parameters[0].Value = Group;
                if (Alle)
                {
                    if (daEintrag.SelectCommand.CommandText.Contains("AND (EntferntJN = 0)"))
                    {
                        daEintrag.SelectCommand.CommandText = daEintrag.SelectCommand.CommandText.Replace("AND (EntferntJN = 0)", " ");
                    }
                }
                DataBase.Fill(daEintrag, dsEintrag1);
            }
		}

        //Neu Nach 16.05.2007 MDA
        public dsEintrag.EintragDataTable Read(Guid IDEintrag)
        {
            dsEintrag.EintragDataTable dt = new dsEintrag.EintragDataTable();
            daEintragOne.SelectCommand.Parameters[0].Value = IDEintrag;
            DataBase.Fill(daEintragOne, dt);
            return dt;
        }



		/// <summary>
		/// Liest  Einträge zur angegebenen Gruppe mit den StringEinschränkungen
		/// X = alle Gruppen
		/// </summary>
		public dsEintrag.EintragDataTable ReadQuery(string tbASZMText, string cbSichtText,string tbWarnhinweisText,char Group)
		{

            dsEintrag.EintragDataTable dt = new dsEintrag.EintragDataTable();
			try 
			{
				string sCombination = /*bUseAndInsteadOr ?*/ " AND " ;//: " OR ";
				string sPrefix		= /*bFulltext ?*/ "%" ;//: "";
				ArrayList al = new ArrayList();
				
				if(tbASZMText.Length > 0) 
				{
					al.Add(" Text like ? ");
					daEintragQuery.SelectCommand.Parameters.Add("Text", OleDbType.VarChar);
					daEintragQuery.SelectCommand.Parameters["Text"].Value = sPrefix + tbASZMText + "%";
				}

				if(cbSichtText.Length > 0) 
				{
					al.Add(" Sicht like ? ");
					daEintragQuery.SelectCommand.Parameters.Add("Sicht", OleDbType.VarChar);
					daEintragQuery.SelectCommand.Parameters["Sicht"].Value = sPrefix + cbSichtText + "%";
				}

				if(tbWarnhinweisText.Length > 0) 
				{
					al.Add(" Warnhinweis like ? ");
					daEintragQuery.SelectCommand.Parameters.Add("Warnhinweis", OleDbType.VarChar);
					daEintragQuery.SelectCommand.Parameters["Warnhinweis"].Value = sPrefix + tbWarnhinweisText + "%";
				}

				//if(Group.Length > 0) 
				{
					al.Add(" EintragGruppe like ? ");
					daEintragQuery.SelectCommand.Parameters.Add("EintragGruppe", OleDbType.VarChar);
					daEintragQuery.SelectCommand.Parameters["EintragGruppe"].Value = sPrefix + Group + "%";
				}

				//daEintrag.SelectCommand.Parameters.Add("EintragGruppe", OleDbType.Char);alAdd(" EntferntJN like ?

				string[] sa = (string[]) al.ToArray(typeof(string));
				if(sa.Length > 0) 
				{
					StringBuilder sb = new StringBuilder();
					sb.Append(" where ");
					int iCount = 0;
					foreach(string s in sa) 
					{
						iCount++;
						sb.Append(s);
						if(iCount < sa.Length)				// den letzten vergessen
							sb.Append(sCombination);		// AND oder OR hinzufügen
					}

					daEintragQuery.SelectCommand.CommandText = _OriginalQuery + sb.ToString()+" AND EntferntJN like 0";// AND EintragGruppe like Group";
					DataBase.Fill(daEintragQuery, dt);
				}

				return dt;

				
			}
			finally 
			{
				daEintragQuery.SelectCommand.CommandText = _OriginalQuery;
				daEintragQuery.SelectCommand.Parameters.Clear();				// Default ohne Parameter
			}
					
		}

		public void writeQuery(dsEintrag.EintragDataTable querytable)
		{
			DataBase.Update(daEintrag,querytable);
		}


		/// <summary>
		/// Liefert die zum Eintrag gehörende Gruppe
		/// </summary>
		public char GROUP
		{
			get 
			{
				return _Group;
			}
		}

		/// <summary>
		/// Függt einen neuen Datensatz der Eintragstabelle hinzu
		/// </summary>
		public void AddNew()
		{
			dsEintrag.EintragRow r	= dsEintrag1.Eintrag.NewEintragRow();
			r.ID					= Guid.NewGuid();
			r.Sicht					= "";
			r.Text					= "";
			r.Warnhinweis			= "";
			r.EintragGruppe			= GROUP.ToString();
			r.EntferntJN			= false;
            r.flag                  = 0;
            r.BedarfsMedikationJN   = false;
            r.SetIDLinkDokumentNull();
            r.lstFormulare = "";

			dsEintrag1.Eintrag.AddEintragRow(r);
			
		}

		/// <summary>
		/// Schreibt die Änderungen in die DB
		/// </summary>
		public void Write() 
		{
			DataBase.Update(daEintrag, dsEintrag1);
		}

		/// <summary>
		/// Liefert die Einträge zur Gruppe
		/// </summary>
        public dsEintrag.EintragDataTable EINTRAEGE 
		{
			get 
			{
				return dsEintrag1.Eintrag;
			}
		}

        //Neu nach 25.06.2007 MDA
        /// <summary>
        /// Liefert alle Zugeoerdnete Pflegedefinitionen
        /// </summary>
        public dsPDx.PDXDataTable GetPDxZuordnungen(Guid IDEintrag)
        {
            dsPDx1.PDX.Clear();
            daPDxZuordnungen.SelectCommand.Parameters[0].Value = IDEintrag;
            DataBase.Fill(daPDxZuordnungen, dsPDx1.PDX);
            return dsPDx1.PDX;
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
            System.Data.OleDb.OleDbConnection oleDbConnection1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBEintrag));
            this.daEintrag = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daEintragAll = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daEintragQuery = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            this.daEintragOne = new System.Data.OleDb.OleDbDataAdapter();
            this.dsPDx1 = new PMDS.Global.db.Pflegeplan.dsPDx();
            this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
            this.daPDxZuordnungen = new System.Data.OleDb.OleDbDataAdapter();
            this.dsEintrag1 = new PMDS.Global.db.Pflegeplan.dsEintrag();
            oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintrag1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=sty041;Integrated Security=SSPI;Initial Catalog=PM" +
    "DS_DemoGross";
            // 
            // daEintrag
            // 
            this.daEintrag.DeleteCommand = this.oleDbDeleteCommand;
            this.daEintrag.InsertCommand = this.oleDbInsertCommand;
            this.daEintrag.SelectCommand = this.oleDbSelectCommand1;
            this.daEintrag.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Eintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"),
                        new System.Data.Common.DataColumnMapping("EntferntJN", "EntferntJN"),
                        new System.Data.Common.DataColumnMapping("Sicht", "Sicht"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("flag", "flag"),
                        new System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"),
                        new System.Data.Common.DataColumnMapping("BedarfsMedikationJN", "BedarfsMedikationJN"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("lstFormulare", "lstFormulare"),
                        new System.Data.Common.DataColumnMapping("PSEKlasse", "PSEKlasse")})});
            this.daEintrag.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [Eintrag] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = resources.GetString("oleDbInsertCommand.CommandText");
            this.oleDbInsertCommand.Connection = oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"),
            new System.Data.OleDb.OleDbParameter("EntferntJN", System.Data.OleDb.OleDbType.Boolean, 0, "EntferntJN"),
            new System.Data.OleDb.OleDbParameter("Sicht", System.Data.OleDb.OleDbType.VarChar, 0, "Sicht"),
            new System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("flag", System.Data.OleDb.OleDbType.Integer, 0, "flag"),
            new System.Data.OleDb.OleDbParameter("IDLinkDokument", System.Data.OleDb.OleDbType.Guid, 0, "IDLinkDokument"),
            new System.Data.OleDb.OleDbParameter("BedarfsMedikationJN", System.Data.OleDb.OleDbType.Boolean, 0, "BedarfsMedikationJN"),
            new System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.Boolean, 0, "OhneZeitBezug"),
            new System.Data.OleDb.OleDbParameter("lstFormulare", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstFormulare"),
            new System.Data.OleDb.OleDbParameter("PSEKlasse", System.Data.OleDb.OleDbType.VarWChar, 0, "PSEKlasse")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.Char, 1, "EintragGruppe")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"),
            new System.Data.OleDb.OleDbParameter("EntferntJN", System.Data.OleDb.OleDbType.Boolean, 0, "EntferntJN"),
            new System.Data.OleDb.OleDbParameter("Sicht", System.Data.OleDb.OleDbType.VarChar, 0, "Sicht"),
            new System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("flag", System.Data.OleDb.OleDbType.Integer, 0, "flag"),
            new System.Data.OleDb.OleDbParameter("IDLinkDokument", System.Data.OleDb.OleDbType.Guid, 0, "IDLinkDokument"),
            new System.Data.OleDb.OleDbParameter("BedarfsMedikationJN", System.Data.OleDb.OleDbType.Boolean, 0, "BedarfsMedikationJN"),
            new System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.Boolean, 0, "OhneZeitBezug"),
            new System.Data.OleDb.OleDbParameter("lstFormulare", System.Data.OleDb.OleDbType.LongVarChar, 0, "lstFormulare"),
            new System.Data.OleDb.OleDbParameter("PSEKlasse", System.Data.OleDb.OleDbType.VarWChar, 0, "PSEKlasse"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Eintrag] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [Eintrag] ([ID], [EintragGruppe], [EntferntJN], [Sicht], [Warnhinweis" +
    "], [Text], [flag], [IDLinkDokument], [BedarfsMedikationJN], [OhneZeitBezug]) VAL" +
    "UES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"),
            new System.Data.OleDb.OleDbParameter("EntferntJN", System.Data.OleDb.OleDbType.Boolean, 0, "EntferntJN"),
            new System.Data.OleDb.OleDbParameter("Sicht", System.Data.OleDb.OleDbType.VarChar, 0, "Sicht"),
            new System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("flag", System.Data.OleDb.OleDbType.Integer, 0, "flag"),
            new System.Data.OleDb.OleDbParameter("IDLinkDokument", System.Data.OleDb.OleDbType.Guid, 0, "IDLinkDokument"),
            new System.Data.OleDb.OleDbParameter("BedarfsMedikationJN", System.Data.OleDb.OleDbType.Boolean, 0, "BedarfsMedikationJN"),
            new System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.Boolean, 0, "OhneZeitBezug")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"),
            new System.Data.OleDb.OleDbParameter("EntferntJN", System.Data.OleDb.OleDbType.Boolean, 0, "EntferntJN"),
            new System.Data.OleDb.OleDbParameter("Sicht", System.Data.OleDb.OleDbType.VarChar, 0, "Sicht"),
            new System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("flag", System.Data.OleDb.OleDbType.Integer, 0, "flag"),
            new System.Data.OleDb.OleDbParameter("IDLinkDokument", System.Data.OleDb.OleDbType.Guid, 0, "IDLinkDokument"),
            new System.Data.OleDb.OleDbParameter("BedarfsMedikationJN", System.Data.OleDb.OleDbType.Boolean, 0, "BedarfsMedikationJN"),
            new System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.Boolean, 0, "OhneZeitBezug"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daEintragAll
            // 
            this.daEintragAll.SelectCommand = this.oleDbSelectCommand3;
            this.daEintragAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Eintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"),
                        new System.Data.Common.DataColumnMapping("EntferntJN", "EntferntJN"),
                        new System.Data.Common.DataColumnMapping("Sicht", "Sicht"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("flag", "flag"),
                        new System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"),
                        new System.Data.Common.DataColumnMapping("BedarfsMedikationJN", "BedarfsMedikationJN"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("lstFormulare", "lstFormulare"),
                        new System.Data.Common.DataColumnMapping("PSEKlasse", "PSEKlasse")})});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = oleDbConnection1;
            // 
            // daEintragQuery
            // 
            this.daEintragQuery.SelectCommand = this.oleDbSelectCommand2;
            this.daEintragQuery.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Eintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"),
                        new System.Data.Common.DataColumnMapping("EntferntJN", "EntferntJN"),
                        new System.Data.Common.DataColumnMapping("Sicht", "Sicht"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("flag", "flag"),
                        new System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"),
                        new System.Data.Common.DataColumnMapping("BedarfsMedikationJN", "BedarfsMedikationJN"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("lstFormulare", "lstFormulare"),
                        new System.Data.Common.DataColumnMapping("PSEKlasse", "PSEKlasse")})});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT        ID, EintragGruppe, EntferntJN, Sicht, Warnhinweis, Text, flag, IDLi" +
    "nkDokument, BedarfsMedikationJN, OhneZeitBezug, lstFormulare, PSEKlasse\r\nFROM   " +
    "         Eintrag";
            this.oleDbSelectCommand2.Connection = oleDbConnection1;
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = "SELECT        ID, EintragGruppe, EntferntJN, Sicht, Warnhinweis, Text, flag, IDLi" +
    "nkDokument, BedarfsMedikationJN, OhneZeitBezug, lstFormulare, PSEKlasse\r\nFROM   " +
    "         Eintrag\r\nWHERE        (ID = ?)";
            this.oleDbSelectCommand4.Connection = oleDbConnection1;
            this.oleDbSelectCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daEintragOne
            // 
            this.daEintragOne.SelectCommand = this.oleDbSelectCommand4;
            this.daEintragOne.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Eintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"),
                        new System.Data.Common.DataColumnMapping("EntferntJN", "EntferntJN"),
                        new System.Data.Common.DataColumnMapping("Sicht", "Sicht"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("flag", "flag"),
                        new System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"),
                        new System.Data.Common.DataColumnMapping("BedarfsMedikationJN", "BedarfsMedikationJN"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("lstFormulare", "lstFormulare"),
                        new System.Data.Common.DataColumnMapping("PSEKlasse", "PSEKlasse")})});
            // 
            // dsPDx1
            // 
            this.dsPDx1.DataSetName = "dsPDx";
            this.dsPDx1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand5
            // 
            this.oleDbSelectCommand5.CommandText = resources.GetString("oleDbSelectCommand5.CommandText");
            this.oleDbSelectCommand5.Connection = oleDbConnection1;
            this.oleDbSelectCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag")});
            // 
            // daPDxZuordnungen
            // 
            this.daPDxZuordnungen.SelectCommand = this.oleDbSelectCommand5;
            this.daPDxZuordnungen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDX", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Klartext", "Klartext"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("ThematischeID", "ThematischeID"),
                        new System.Data.Common.DataColumnMapping("EntferntJN", "EntferntJN"),
                        new System.Data.Common.DataColumnMapping("Definition", "Definition"),
                        new System.Data.Common.DataColumnMapping("Gruppe", "Gruppe"),
                        new System.Data.Common.DataColumnMapping("LokalisierungsTyp", "LokalisierungsTyp"),
                        new System.Data.Common.DataColumnMapping("WundeJN", "WundeJN")})});
            // 
            // dsEintrag1
            // 
            this.dsEintrag1.DataSetName = "dsEintrag";
            this.dsEintrag1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsPDx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintrag1)).EndInit();

		}
		#endregion
	}
}
