//----------------------------------------------------------------------------------------------
//  Erstellt am:	25.10.2005
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
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
	//----------------------------------------------------------------------------
	/// <summary>
	/// DB Zugriffsklasse auf die Formularverwaltung
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBFormular : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private dsFormular dsFormular1;
        private System.Data.OleDb.OleDbDataAdapter daFormularAll;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
        private System.Data.OleDb.OleDbDataAdapter daFormularOne;
        private System.Data.OleDb.OleDbCommand oleDbCommand5;
        private System.Data.OleDb.OleDbCommand oleDbCommand6;
        private System.Data.OleDb.OleDbCommand oleDbCommand7;
        private System.Data.OleDb.OleDbCommand oleDbCommand8;
		private System.ComponentModel.Container components = null;

		public DBFormular(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		public DBFormular()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle Formulare in der DB
		/// </summary>
		//----------------------------------------------------------------------------
        public dsFormular.FormularDataTable Read()
		{
			dsFormular.FormularDataTable dt = new dsFormular.FormularDataTable();
			DataBase.Fill(daFormularAll, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert einen einzelnen
		/// </summary>
		//----------------------------------------------------------------------------
		public dsFormular.FormularDataTable Read(Guid ID)
		{
			dsFormular.FormularDataTable dt = new dsFormular.FormularDataTable();
			daFormularOne.SelectCommand.Parameters[0].Value = ID;
			DataBase.Fill(daFormularOne, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Ab in die DB
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write(dsFormular.FormularDataTable dt)
		{
			DataBase.Update(daFormularAll, dt); 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBFormular));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.dsFormular1 = new PMDS.Global.db.Global.dsFormular();
            this.daFormularAll = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.daFormularOne = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormular1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=MSOLEDBSQL.1;Data Source=sty041\\MSSQL2019;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDS_DemoGross";
            // 
            // dsFormular1
            // 
            this.dsFormular1.DataSetName = "dsFormular";
            this.dsFormular1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsFormular1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daFormularAll
            // 
            this.daFormularAll.DeleteCommand = this.oleDbDeleteCommand;
            this.daFormularAll.InsertCommand = this.oleDbCommand1;
            this.daFormularAll.SelectCommand = this.oleDbCommand4;
            this.daFormularAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Formular", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("BLOP", "BLOP"),
                        new System.Data.Common.DataColumnMapping("GUI", "GUI"),
                        new System.Data.Common.DataColumnMapping("InNotfallAnzeigenJN", "InNotfallAnzeigenJN"),
                        new System.Data.Common.DataColumnMapping("PDF_BLOP", "PDF_BLOP"),
                        new System.Data.Common.DataColumnMapping("NeuanlageSperren", "NeuanlageSperren"),
                        new System.Data.Common.DataColumnMapping("lstIDBerufsgruppe", "lstIDBerufsgruppe"),
                        new System.Data.Common.DataColumnMapping("EditHours", "EditHours")})});
            this.daFormularAll.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM \"PMDS_DemoGross\".\"dbo\".\"Formular\" WHERE ((\"ID\" = ?))";
            this.oleDbDeleteCommand.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("BLOP", System.Data.OleDb.OleDbType.LongVarChar, 0, "BLOP"),
            new System.Data.OleDb.OleDbParameter("GUI", System.Data.OleDb.OleDbType.Boolean, 0, "GUI"),
            new System.Data.OleDb.OleDbParameter("InNotfallAnzeigenJN", System.Data.OleDb.OleDbType.Boolean, 0, "InNotfallAnzeigenJN"),
            new System.Data.OleDb.OleDbParameter("PDF_BLOP", System.Data.OleDb.OleDbType.LongVarBinary, 0, "PDF_BLOP"),
            new System.Data.OleDb.OleDbParameter("NeuanlageSperren", System.Data.OleDb.OleDbType.Boolean, 0, "NeuanlageSperren"),
            new System.Data.OleDb.OleDbParameter("lstIDBerufsgruppe", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstIDBerufsgruppe"),
            new System.Data.OleDb.OleDbParameter("EditHours", System.Data.OleDb.OleDbType.Integer, 0, "EditHours")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "SELECT        ID, Name, Bezeichnung, BLOP, GUI, InNotfallAnzeigenJN, PDF_BLOP, Ne" +
    "uanlageSperren, lstIDBerufsgruppe, EditHours\r\nFROM            dbo.Formular\r\nORDE" +
    "R BY Name";
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("BLOP", System.Data.OleDb.OleDbType.LongVarChar, 0, "BLOP"),
            new System.Data.OleDb.OleDbParameter("GUI", System.Data.OleDb.OleDbType.Boolean, 0, "GUI"),
            new System.Data.OleDb.OleDbParameter("InNotfallAnzeigenJN", System.Data.OleDb.OleDbType.Boolean, 0, "InNotfallAnzeigenJN"),
            new System.Data.OleDb.OleDbParameter("PDF_BLOP", System.Data.OleDb.OleDbType.LongVarBinary, 0, "PDF_BLOP"),
            new System.Data.OleDb.OleDbParameter("NeuanlageSperren", System.Data.OleDb.OleDbType.Boolean, 0, "NeuanlageSperren"),
            new System.Data.OleDb.OleDbParameter("lstIDBerufsgruppe", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstIDBerufsgruppe"),
            new System.Data.OleDb.OleDbParameter("EditHours", System.Data.OleDb.OleDbType.Integer, 0, "EditHours"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daFormularOne
            // 
            this.daFormularOne.DeleteCommand = this.oleDbCommand5;
            this.daFormularOne.InsertCommand = this.oleDbCommand6;
            this.daFormularOne.SelectCommand = this.oleDbCommand7;
            this.daFormularOne.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Formular", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("BLOP", "BLOP"),
                        new System.Data.Common.DataColumnMapping("GUI", "GUI"),
                        new System.Data.Common.DataColumnMapping("InNotfallAnzeigenJN", "InNotfallAnzeigenJN"),
                        new System.Data.Common.DataColumnMapping("PDF_BLOP", "PDF_BLOP"),
                        new System.Data.Common.DataColumnMapping("NeuanlageSperren", "NeuanlageSperren"),
                        new System.Data.Common.DataColumnMapping("lstIDBerufsgruppe", "lstIDBerufsgruppe"),
                        new System.Data.Common.DataColumnMapping("EditHours", "EditHours")})});
            this.daFormularOne.UpdateCommand = this.oleDbCommand8;
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = "DELETE FROM \"PMDS_DemoGross\".\"dbo\".\"Formular\" WHERE ((\"ID\" = ?))";
            this.oleDbCommand5.Connection = this.oleDbConnection1;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand6
            // 
            this.oleDbCommand6.CommandText = resources.GetString("oleDbCommand6.CommandText");
            this.oleDbCommand6.Connection = this.oleDbConnection1;
            this.oleDbCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("BLOP", System.Data.OleDb.OleDbType.LongVarChar, 0, "BLOP"),
            new System.Data.OleDb.OleDbParameter("GUI", System.Data.OleDb.OleDbType.Boolean, 0, "GUI"),
            new System.Data.OleDb.OleDbParameter("InNotfallAnzeigenJN", System.Data.OleDb.OleDbType.Boolean, 0, "InNotfallAnzeigenJN"),
            new System.Data.OleDb.OleDbParameter("PDF_BLOP", System.Data.OleDb.OleDbType.LongVarBinary, 0, "PDF_BLOP"),
            new System.Data.OleDb.OleDbParameter("NeuanlageSperren", System.Data.OleDb.OleDbType.Boolean, 0, "NeuanlageSperren"),
            new System.Data.OleDb.OleDbParameter("lstIDBerufsgruppe", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstIDBerufsgruppe"),
            new System.Data.OleDb.OleDbParameter("EditHours", System.Data.OleDb.OleDbType.Integer, 0, "EditHours")});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = "SELECT        ID, Name, Bezeichnung, BLOP, GUI, InNotfallAnzeigenJN, PDF_BLOP, Ne" +
    "uanlageSperren, lstIDBerufsgruppe, EditHours\r\nFROM            dbo.Formular\r\nWHER" +
    "E        (ID = ?)\r\nORDER BY Name";
            this.oleDbCommand7.Connection = this.oleDbConnection1;
            this.oleDbCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 1024, "ID")});
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = resources.GetString("oleDbCommand8.CommandText");
            this.oleDbCommand8.Connection = this.oleDbConnection1;
            this.oleDbCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("BLOP", System.Data.OleDb.OleDbType.LongVarChar, 0, "BLOP"),
            new System.Data.OleDb.OleDbParameter("GUI", System.Data.OleDb.OleDbType.Boolean, 0, "GUI"),
            new System.Data.OleDb.OleDbParameter("InNotfallAnzeigenJN", System.Data.OleDb.OleDbType.Boolean, 0, "InNotfallAnzeigenJN"),
            new System.Data.OleDb.OleDbParameter("PDF_BLOP", System.Data.OleDb.OleDbType.LongVarBinary, 0, "PDF_BLOP"),
            new System.Data.OleDb.OleDbParameter("NeuanlageSperren", System.Data.OleDb.OleDbType.Boolean, 0, "NeuanlageSperren"),
            new System.Data.OleDb.OleDbParameter("lstIDBerufsgruppe", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstIDBerufsgruppe"),
            new System.Data.OleDb.OleDbParameter("EditHours", System.Data.OleDb.OleDbType.Integer, 0, "EditHours"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsFormular1)).EndInit();

		}
		#endregion
	}
}
