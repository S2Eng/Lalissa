//----------------------------------------------------------------------------------------------
//	DBEintragZusatz.cs
//  Zugriffsfunktionen auf die Zusatzinformationen zur Maßnahme
//  Erstellt am:	23.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using RBU;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Summary description for DBAbteilungEintrag.
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBEintragZusatz : System.ComponentModel.Component
	{

        private Guid _IDEintrag;
		private dsEintragZusatz dsEintragZusatz1;
		private System.Data.OleDb.OleDbDataAdapter daEintragZusatz;
		private System.Data.OleDb.OleDbDataAdapter daEintragZusatzSingle;
		private System.Data.OleDb.OleDbCommand oleDbCommand3;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		//----------------------------------------------------------------------------
		public DBEintragZusatz(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBEintragZusatz()
		{
			InitializeComponent();
		}



		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Zusatzwerte zu einem bestimmten Eintrag zu einer bestimmten Abteilung
		/// <summary>
		//----------------------------------------------------------------------------
		public dsEintragZusatz.EintragZusatzRow Read(Guid IDEintrag, Guid IDAbteilung)
		{
			daEintragZusatzSingle.SelectCommand.Parameters[0].Value = IDEintrag;
			daEintragZusatzSingle.SelectCommand.Parameters[1].Value = IDAbteilung;
			dsEintragZusatz ds = new dsEintragZusatz();
			DataBase.Fill(daEintragZusatzSingle, ds);
			if(ds.EintragZusatz.Rows.Count == 0)
				return null;
			return ds.EintragZusatz[0];
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Standardwerte für neue Row
		/// </summary>
		//----------------------------------------------------------------------------
		private void SetDefaultValuesForRow(dsEintragZusatz.EintragZusatzRow r) 
		{
			r.WochenTage = 127;						// Montag bis Sonntag ausgewählt (Bitcodiert 1=MO)
			r.Intervall	 = 24;						// 24 Stunden
            r.UntertaegigJN = true;				    // lt. os 21.3.2007 ist default eine Benutzerdefinierte M Serie
            r.IDMassnahmenserien = Guid.Empty;		// lt. os 21.3.2007 ist default eine Benutzerdefinierte M Serie
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// Liest die Zusatzwerte des Angegebenen Eintrages und legt einen generellen DS, 
		/// und einen Abteilungsspezifischen DS an wenn er noch 
		/// nicht vorhanden ist.
		//----------------------------------------------------------------------------
		public void Read(Guid IDEintrag)
		{
			_IDEintrag		= IDEintrag;
			dsEintragZusatz1.Clear();
			daEintragZusatz.SelectCommand.Parameters[0].Value = IDEintrag;
			DataBase.Fill(daEintragZusatz, dsEintragZusatz1);
			if(dsEintragZusatz1.EintragZusatz.Count == 0) 
			{
				AddNew();
			}
		}

		public dsEintragZusatz.EintragZusatzRow AddNew()
		{
			return AddNew(Guid.Empty, false);
		}

		public dsEintragZusatz.EintragZusatzRow AddNew(Guid IDAbteilung)
		{
			return AddNew(IDAbteilung, true);
		}
		//----------------------------------------------------------------------------
		/// <summary>
		/// Függt einen neuen Datensatz der Eintragstabelle hinzu (Generelle Abteilung)
		/// </summary>
		//----------------------------------------------------------------------------
		private dsEintragZusatz.EintragZusatzRow AddNew(Guid IDAbteilung, bool bUseAbteilung)
		{
			dsEintragZusatz.EintragZusatzRow r = dsEintragZusatz1.EintragZusatz.NewEintragZusatzRow();
			if(bUseAbteilung)
				r.IDAbteilung = IDAbteilung;
			else
				r.IDAbteilung	= Guid.Empty;
			r.IDEintrag		= _IDEintrag;
			r.LokalisierungJN	= false;
			r.ParalellJN		= false;
			r.WochenTage		= 0;
			r.Dauer				= 0;
			r.EinmaligJN		= false;
			r.EvalTage			= 0;
			r.Intervall			= 0;
			r.IntervallTyp		= 0;
			r.RMOptionalJN		= false;
			SetDefaultValuesForRow(r);
			dsEintragZusatz1.EintragZusatz.AddEintragZusatzRow(r);
			return r;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Schreibt die Änderungen in die DB
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write() 
		{
            // Bei den Zeitbereichserien wird Guid.Empty zu null
            foreach (dsEintragZusatz.EintragZusatzRow r in ZUSATZEINTRAG)
            {
                if (!r.IsIDZeitbereichSerienNull() && r.IDZeitbereichSerien == Guid.Empty)
                    r.SetIDZeitbereichSerienNull();
            }

			DataBase.Update(daEintragZusatz, dsEintragZusatz1);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert einen Eintragzusatz Datatable mit immer einer enthaltenen Row
		/// </summary>
		//----------------------------------------------------------------------------
		public dsEintragZusatz.EintragZusatzDataTable	ZUSATZEINTRAG
		{
			get 
			{
				return dsEintragZusatz1.EintragZusatz;
			}
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
            System.Data.OleDb.OleDbConnection oleDbConnection1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBEintragZusatz));
            this.dsEintragZusatz1 = new dsEintragZusatz();
            this.daEintragZusatz = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daEintragZusatzSingle = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintragZusatz1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // dsEintragZusatz1
            // 
            this.dsEintragZusatz1.DataSetName = "dsEintragZusatz";
            this.dsEintragZusatz1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsEintragZusatz1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daEintragZusatz
            // 
            this.daEintragZusatz.DeleteCommand = this.oleDbDeleteCommand1;
            this.daEintragZusatz.InsertCommand = this.oleDbInsertCommand1;
            this.daEintragZusatz.SelectCommand = this.oleDbSelectCommand1;
            this.daEintragZusatz.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "EintragZusatz", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("Intervall", "Intervall"),
                        new System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"),
                        new System.Data.Common.DataColumnMapping("IntervallTyp", "IntervallTyp"),
                        new System.Data.Common.DataColumnMapping("EvalTage", "EvalTage"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("ParalellJN", "ParalellJN"),
                        new System.Data.Common.DataColumnMapping("Dauer", "Dauer"),
                        new System.Data.Common.DataColumnMapping("LokalisierungJN", "LokalisierungJN"),
                        new System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("UntertaegigJN", "UntertaegigJN"),
                        new System.Data.Common.DataColumnMapping("IDMassnahmenserien", "IDMassnahmenserien"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereichSerien", "IDZeitbereichSerien"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich", "IDZeitbereich")})});
            this.daEintragZusatz.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [EintragZusatz] WHERE (([IDEintrag] = ?) AND ([IDAbteilung] = ?))";
            this.oleDbDeleteCommand1.Connection = oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDEintrag", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAbteilung", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.Integer, 0, "Intervall"),
            new System.Data.OleDb.OleDbParameter("WochenTage", System.Data.OleDb.OleDbType.Integer, 0, "WochenTage"),
            new System.Data.OleDb.OleDbParameter("IntervallTyp", System.Data.OleDb.OleDbType.Integer, 0, "IntervallTyp"),
            new System.Data.OleDb.OleDbParameter("EvalTage", System.Data.OleDb.OleDbType.Integer, 0, "EvalTage"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"),
            new System.Data.OleDb.OleDbParameter("ParalellJN", System.Data.OleDb.OleDbType.Boolean, 0, "ParalellJN"),
            new System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 0, "Dauer"),
            new System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.Boolean, 0, "LokalisierungJN"),
            new System.Data.OleDb.OleDbParameter("EinmaligJN", System.Data.OleDb.OleDbType.Boolean, 0, "EinmaligJN"),
            new System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "RMOptionalJN"),
            new System.Data.OleDb.OleDbParameter("UntertaegigJN", System.Data.OleDb.OleDbType.Boolean, 0, "UntertaegigJN"),
            new System.Data.OleDb.OleDbParameter("IDMassnahmenserien", System.Data.OleDb.OleDbType.Guid, 0, "IDMassnahmenserien"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereichSerien", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereichSerien"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.Integer, 0, "Intervall"),
            new System.Data.OleDb.OleDbParameter("WochenTage", System.Data.OleDb.OleDbType.Integer, 0, "WochenTage"),
            new System.Data.OleDb.OleDbParameter("IntervallTyp", System.Data.OleDb.OleDbType.Integer, 0, "IntervallTyp"),
            new System.Data.OleDb.OleDbParameter("EvalTage", System.Data.OleDb.OleDbType.Integer, 0, "EvalTage"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"),
            new System.Data.OleDb.OleDbParameter("ParalellJN", System.Data.OleDb.OleDbType.Boolean, 0, "ParalellJN"),
            new System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 0, "Dauer"),
            new System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.Boolean, 0, "LokalisierungJN"),
            new System.Data.OleDb.OleDbParameter("EinmaligJN", System.Data.OleDb.OleDbType.Boolean, 0, "EinmaligJN"),
            new System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "RMOptionalJN"),
            new System.Data.OleDb.OleDbParameter("UntertaegigJN", System.Data.OleDb.OleDbType.Boolean, 0, "UntertaegigJN"),
            new System.Data.OleDb.OleDbParameter("IDMassnahmenserien", System.Data.OleDb.OleDbType.Guid, 0, "IDMassnahmenserien"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereichSerien", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereichSerien"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich"),
            new System.Data.OleDb.OleDbParameter("Original_IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDEintrag", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAbteilung", System.Data.DataRowVersion.Original, null)});
            // 
            // daEintragZusatzSingle
            // 
            this.daEintragZusatzSingle.SelectCommand = this.oleDbCommand3;
            this.daEintragZusatzSingle.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "EintragZusatz", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("Intervall", "Intervall"),
                        new System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"),
                        new System.Data.Common.DataColumnMapping("IntervallTyp", "IntervallTyp"),
                        new System.Data.Common.DataColumnMapping("EvalTage", "EvalTage"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("ParalellJN", "ParalellJN"),
                        new System.Data.Common.DataColumnMapping("Dauer", "Dauer"),
                        new System.Data.Common.DataColumnMapping("LokalisierungJN", "LokalisierungJN"),
                        new System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("UntertaegigJN", "UntertaegigJN"),
                        new System.Data.Common.DataColumnMapping("IDMassnahmenserien", "IDMassnahmenserien")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            ((System.ComponentModel.ISupportInitialize)(this.dsEintragZusatz1)).EndInit();

		}
		#endregion
	}
}
