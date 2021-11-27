//----------------------------------------------------------------------------------------------
//  Erstellt am:	19.8.2005
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using PMDS.Global;using PMDS.Data.Patient;
using System.Data.OleDb;
using System.Text;
using RBU;
using PMDS.Global.db.Patient;


namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// DB Zugriffsklasse auf die Medikamente
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBMedikament : System.ComponentModel.Component
	{
		private string					_OriginalQueryBig;
        private string _OriginalQuerySmall;

		private System.Data.OleDb.OleDbDataAdapter daMedikament;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private dsMedikament dsMedikament1;
        public OleDbDataAdapter daMedikament2;
        private OleDbCommand oleDbCommand1;
        private OleDbCommand oleDbCommand3;
		
		private System.ComponentModel.Container components = null;
        private OleDbDataAdapter daMedikamentSmall;
        private OleDbCommand oleDbCommand7;

        public enum eTypeSelMedikament
        {
            ExternIDOrderByGültigkeitsdatumDesc = 0,
            ID = 1,
            Bezeichnung = 2
        }

        public string seldaMedikament2 = "";
        public static PMDS.Global.db.Patient.dsMedikament _dsMedikament = null;
        private OleDbCommand oleDbInsertCommand;
        private OleDbCommand oleDbUpdateCommand;
        public static bool _MedikamenteLoaded = false;





        public void initControl()
        {
            try
            {
                this.seldaMedikament2 = this.daMedikament2.SelectCommand.CommandText;

            }
            catch (Exception ex)
            {
                throw new Exception("DBMedikament.initControl: " + ex.ToString());
            }
        }
		
 
		public DBMedikament(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			_OriginalQueryBig = daMedikament.SelectCommand.CommandText;
            _OriginalQuerySmall = daMedikamentSmall.SelectCommand.CommandText;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBMedikament()
		{
			InitializeComponent();
            _OriginalQueryBig = daMedikament.SelectCommand.CommandText;
            _OriginalQuerySmall = daMedikamentSmall.SelectCommand.CommandText;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Schreibt den übergebenen Datatable
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write(dsMedikament.MedikamentDataTable dt) 
		{
			DataBase.Update(daMedikament, dt);
		}


        public bool getMedikament(System.Guid ID, dsMedikament ds, eTypeSelMedikament typeSel, string ExtID, string Bezeichnung)
        {
            try
            {
                this.daMedikament2.SelectCommand.CommandText = this.seldaMedikament2;
                this.daMedikament2.SelectCommand.Parameters.Clear();
                PMDS.Global.dbBase.setConnection(this.daMedikament2, DataBase.CONNECTION);

                if (typeSel == eTypeSelMedikament.ExternIDOrderByGültigkeitsdatumDesc)
                {
                    string sWhere = " where EXT_ID='" + ExtID.Trim() + "' and Aktuell=1";
                    string sOrderBy = " order by Gültigkeitsdatum desc ";
                    this.daMedikament2.SelectCommand.CommandText += sWhere + sOrderBy;
                    //this.daMedikament2.SelectCommand.Parameters.AddWithValue("EXT_ID", ID);
                }
                else if (typeSel == eTypeSelMedikament.ID)
                {
                    string sWhere = " where ID='" + ID.ToString() + "' ";
                    this.daMedikament2.SelectCommand.CommandText += sWhere;
                }
                else if (typeSel == eTypeSelMedikament.Bezeichnung)
                {
                    string sWhere = " where Bezeichnung like '%" + Bezeichnung.ToString() + "%' and  Aktuell=1";
                    this.daMedikament2.SelectCommand.CommandText += sWhere;
                }
                else
                    throw new Exception("DBMedikament.getMedikament: typSel '" + typeSel.ToString() + "' not exists!");

                this.daMedikament2.Fill(ds.Medikament);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("DBMedikament.getMedikament: " + ex.ToString());
            }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle Ds sortiert nach Bezeichnung
		/// </summary>
		//----------------------------------------------------------------------------
		public dsMedikament.MedikamentDataTable AllMedikamenteBig(int Aktuell, bool ReadAll) 
		{
            dsMedikament.MedikamentDataTable dt = new  dsMedikament.MedikamentDataTable();
			try 
			{
				daMedikament.SelectCommand.CommandText = _OriginalQueryBig;
                //string sWhere = this.GetWhereAktuell(true);
                string sWhereAktuell = " where 1 = 1";
                if (Aktuell != -1)
                {
                    sWhereAktuell += " and Aktuell=" + Aktuell.ToString()  +  " ";
                }
                if (!ReadAll)
                {
                    sWhereAktuell += " and ID = '" + Guid.Empty.ToString() + "'";
                }

                daMedikament.SelectCommand.CommandText += sWhereAktuell + " order by bezeichnung ";
				DataBase.Fill(daMedikament, dt);
			}
			finally 
			{
				ResetQuery();
			}
			return dt;
		}

        public void LoadAllMedikamente(bool loadnew)
        {
            try
            {
                if (!DBMedikament._MedikamenteLoaded || loadnew)
                {
                    DBMedikament._dsMedikament = new dsMedikament();
                    daMedikamentSmall.SelectCommand.CommandText = _OriginalQuerySmall;
                    //string sWhere = this.GetWhereAktuell(true);
                    daMedikamentSmall.SelectCommand.CommandText += " order by bezeichnung ";
                    DataBase.Fill(daMedikamentSmall, DBMedikament._dsMedikament.MedikamentSmall);
              
                    DBMedikament._MedikamenteLoaded = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("LoadAllMedikamente: " + ex.ToString());
            }
        }

        public bool ClearMedikamente()
        {
            try
            {
                DBMedikament._dsMedikament = new dsMedikament();
                DBMedikament._dsMedikament.MedikamentSmall.Clear();
                DBMedikament._MedikamenteLoaded = true;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ClearMedikamente: " + ex.ToString());
            }
        }

        public dsMedikament.MedikamentSmallRow[] GetMedikamente(int aktuell, System.Guid IDMed)
        {
            try
            {
                if (aktuell != -1)
                {
                    dsMedikament.MedikamentSmallRow[] arrMed = (dsMedikament.MedikamentSmallRow[])DBMedikament._dsMedikament.MedikamentSmall.Select("Aktuell=" + aktuell.ToString(), "");
                    return arrMed;
                }
                else if (IDMed != null)
                {
                    dsMedikament.MedikamentSmallRow[] arrMed = (dsMedikament.MedikamentSmallRow[])DBMedikament._dsMedikament.MedikamentSmall.Select("ID='" + IDMed.ToString() + "'", "");
                    return arrMed;
                }
                else
                {
                    throw new Exception("GetMedikamente: not allowed.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetMedikamente: " + ex.ToString());
            }
        }



        public string GetWhereAktuell1(bool WithWhere)
        {
            if (WithWhere)
            {
                return " where Aktuell=1";
            }
            else
            {
                return " Aktuell=1";
            }
        }
		//----------------------------------------------------------------------------
		/// <summary>
		/// Ermittelt den Datensatz zur ID und liefert einen Datatable zurück
		/// der ist leer wenn der Datensatz nicht gefunden wurde
		/// </summary>
		//----------------------------------------------------------------------------
		public dsMedikament.MedikamentDataTable ReadMedikament(Guid IDMedikament) 
		{
            dsMedikament.MedikamentDataTable dt = new dsMedikament.MedikamentDataTable();
			try 
			{
				daMedikament.SelectCommand.CommandText = _OriginalQueryBig + " where ID = ? ";
                //string sWhere = this.GetWhereAktuell1(false);
                //daMedikament.SelectCommand.CommandText += " and " + sWhere;
				daMedikament.SelectCommand.Parameters.Add("ID", OleDbType.Guid);
				daMedikament.SelectCommand.Parameters[0].Value = IDMedikament;
				DataBase.Fill(daMedikament, dt);
			}
			finally 
			{
				ResetQuery();
			}
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert einen Datatable mit einem neuen Medikamenten Eintrag
		/// </summary>
		//----------------------------------------------------------------------------
		public dsMedikament.MedikamentRow New(dsMedikament.MedikamentDataTable dt) 
		{
			dsMedikament.MedikamentRow r =  dt.NewMedikamentRow();
			r.ID = Guid.NewGuid();
            r.EXT_ID = "";
            r.BARCODE= "";
            r.Zulassungsnummer= "";
            r.Bezeichnung= "";
            r.LangText= "";
            r.Einheit= "";
            r.Gruppe = "";
            r.Herrichten = 0;
            r.AerztlichevorbereitungJN = false;
            r.Verabreichungsart = 0;
            r.Applikationsform = "";
            r.Packungsgroesse = 0;
            r.Packungsanzahl = 0;
            r.Packungseinheit = "";

            r.SetGültigkeitsdatumNull();
            r.Lagervorschrift = "";
            r.SetImportiertAmNull();
            r.Importiert = false;
            r.Aktuell = false;
            r.Erstattungscode = "";
            r.Kassenzeichen = "";
            r.Lieferant = "";

			dt.AddMedikamentRow(r);
			return r;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Ermittelt sämtliche Datensätze welchen den übergebenen Kriterien entsprechen
		/// Leere Strings werden nicht ausgewertet
		/// </summary>
		//----------------------------------------------------------------------------
		public dsMedikament.MedikamentDataTable ReadMedikament(string LikeforBezeichnung, string LikeforLangText, 
                                                    string LikeForEinheit, string LikeForGruppe, bool bFulltext, 
                                                    bool bUseAndInsteadOrxy, int Aktuell) 
		{
            dsMedikament.MedikamentDataTable dt = new  dsMedikament.MedikamentDataTable();
			try 
			{
                string sCombination = " and ";   //bUseAndInsteadOr ? " AND " : " OR ";
				string sPrefix		= bFulltext ? "%" : "";
				ArrayList al = new ArrayList();
				
				if(LikeforBezeichnung.Length > 0) 
				{
					al.Add(" Bezeichnung like ? ");
					daMedikament.SelectCommand.Parameters.Add("Bezeichnung", OleDbType.VarChar);
					daMedikament.SelectCommand.Parameters["Bezeichnung"].Value = sPrefix + LikeforBezeichnung + "%";
				}

				if(LikeforLangText.Length > 0) 
				{
					al.Add(" LangText like ? ");
					daMedikament.SelectCommand.Parameters.Add("LangText", OleDbType.VarChar);
					daMedikament.SelectCommand.Parameters["LangText"].Value = sPrefix + LikeforLangText + "%";
				}

				if(LikeForEinheit.Length > 0) 
				{
					al.Add(" Einheit like ? ");
					daMedikament.SelectCommand.Parameters.Add("Einheit", OleDbType.VarChar);
					daMedikament.SelectCommand.Parameters["Einheit"].Value = sPrefix + LikeForEinheit + "%";
				}

				if(LikeForGruppe.Length > 0) 
				{
					al.Add(" Gruppe like ? ");
					daMedikament.SelectCommand.Parameters.Add("Gruppe", OleDbType.VarChar);
					daMedikament.SelectCommand.Parameters["Gruppe"].Value = sPrefix + LikeForGruppe + "%";
				}

                if (Aktuell != -1)
                {
                    al.Add(" Aktuell = " + Aktuell .ToString()+ " ");
                }

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

					daMedikament.SelectCommand.CommandText = _OriginalQueryBig + sb.ToString();
                    //string sWhere = this.GetWhereAktuell(false);
                    //daMedikament.SelectCommand.CommandText += " and " + sWhere;
					DataBase.Fill(daMedikament, dt);
				}

				return dt;

				
			}
			finally 
			{
				ResetQuery();
			}

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Zurücksetzen Select in den Originalzustand
		/// </summary>
		//----------------------------------------------------------------------------
		private void ResetQuery() 
		{
			daMedikament.SelectCommand.CommandText = _OriginalQueryBig;
            daMedikamentSmall.SelectCommand.CommandText = _OriginalQuerySmall;
			daMedikament.SelectCommand.Parameters.Clear();				// Default ohne Parameter
            daMedikamentSmall.SelectCommand.Parameters.Clear();	
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBMedikament));
            this.daMedikament = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daMedikament2 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.daMedikamentSmall = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.dsMedikament1 = new PMDS.Global.db.Patient.dsMedikament();
            ((System.ComponentModel.ISupportInitialize)(this.dsMedikament1)).BeginInit();
            // 
            // daMedikament
            // 
            this.daMedikament.DeleteCommand = this.oleDbDeleteCommand1;
            this.daMedikament.InsertCommand = this.oleDbInsertCommand1;
            this.daMedikament.SelectCommand = this.oleDbSelectCommand1;
            this.daMedikament.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Medikament", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("EXT_ID", "EXT_ID"),
                        new System.Data.Common.DataColumnMapping("BARCODE", "BARCODE"),
                        new System.Data.Common.DataColumnMapping("Zulassungsnummer", "Zulassungsnummer"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("LangText", "LangText"),
                        new System.Data.Common.DataColumnMapping("Einheit", "Einheit"),
                        new System.Data.Common.DataColumnMapping("Gruppe", "Gruppe"),
                        new System.Data.Common.DataColumnMapping("Herrichten", "Herrichten"),
                        new System.Data.Common.DataColumnMapping("AerztlichevorbereitungJN", "AerztlichevorbereitungJN"),
                        new System.Data.Common.DataColumnMapping("Verabreichungsart", "Verabreichungsart"),
                        new System.Data.Common.DataColumnMapping("Applikationsform", "Applikationsform"),
                        new System.Data.Common.DataColumnMapping("Packungsgroesse", "Packungsgroesse"),
                        new System.Data.Common.DataColumnMapping("Packungsanzahl", "Packungsanzahl"),
                        new System.Data.Common.DataColumnMapping("Packungseinheit", "Packungseinheit"),
                        new System.Data.Common.DataColumnMapping("Gültigkeitsdatum", "Gültigkeitsdatum"),
                        new System.Data.Common.DataColumnMapping("Lagervorschrift", "Lagervorschrift"),
                        new System.Data.Common.DataColumnMapping("ImportiertAm", "ImportiertAm"),
                        new System.Data.Common.DataColumnMapping("Importiert", "Importiert"),
                        new System.Data.Common.DataColumnMapping("Aktuell", "Aktuell"),
                        new System.Data.Common.DataColumnMapping("Erstattungscode", "Erstattungscode"),
                        new System.Data.Common.DataColumnMapping("Kassenzeichen", "Kassenzeichen"),
                        new System.Data.Common.DataColumnMapping("Lieferant", "Lieferant")})});
            this.daMedikament.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Medikament] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("EXT_ID", System.Data.OleDb.OleDbType.VarChar, 0, "EXT_ID"),
            new System.Data.OleDb.OleDbParameter("BARCODE", System.Data.OleDb.OleDbType.VarChar, 0, "BARCODE"),
            new System.Data.OleDb.OleDbParameter("Zulassungsnummer", System.Data.OleDb.OleDbType.VarChar, 0, "Zulassungsnummer"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("LangText", System.Data.OleDb.OleDbType.LongVarChar, 0, "LangText"),
            new System.Data.OleDb.OleDbParameter("Einheit", System.Data.OleDb.OleDbType.VarChar, 0, "Einheit"),
            new System.Data.OleDb.OleDbParameter("Gruppe", System.Data.OleDb.OleDbType.VarChar, 0, "Gruppe"),
            new System.Data.OleDb.OleDbParameter("Herrichten", System.Data.OleDb.OleDbType.Integer, 0, "Herrichten"),
            new System.Data.OleDb.OleDbParameter("AerztlichevorbereitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "AerztlichevorbereitungJN"),
            new System.Data.OleDb.OleDbParameter("Verabreichungsart", System.Data.OleDb.OleDbType.Integer, 0, "Verabreichungsart"),
            new System.Data.OleDb.OleDbParameter("Applikationsform", System.Data.OleDb.OleDbType.VarChar, 0, "Applikationsform"),
            new System.Data.OleDb.OleDbParameter("Packungsgroesse", System.Data.OleDb.OleDbType.Double, 0, "Packungsgroesse"),
            new System.Data.OleDb.OleDbParameter("Packungsanzahl", System.Data.OleDb.OleDbType.Integer, 0, "Packungsanzahl"),
            new System.Data.OleDb.OleDbParameter("Packungseinheit", System.Data.OleDb.OleDbType.VarChar, 0, "Packungseinheit"),
            new System.Data.OleDb.OleDbParameter("Gültigkeitsdatum", System.Data.OleDb.OleDbType.Date, 16, "Gültigkeitsdatum"),
            new System.Data.OleDb.OleDbParameter("Lagervorschrift", System.Data.OleDb.OleDbType.VarWChar, 0, "Lagervorschrift"),
            new System.Data.OleDb.OleDbParameter("ImportiertAm", System.Data.OleDb.OleDbType.Date, 16, "ImportiertAm"),
            new System.Data.OleDb.OleDbParameter("Importiert", System.Data.OleDb.OleDbType.Boolean, 0, "Importiert"),
            new System.Data.OleDb.OleDbParameter("Aktuell", System.Data.OleDb.OleDbType.Boolean, 0, "Aktuell"),
            new System.Data.OleDb.OleDbParameter("Erstattungscode", System.Data.OleDb.OleDbType.VarWChar, 0, "Erstattungscode"),
            new System.Data.OleDb.OleDbParameter("Kassenzeichen", System.Data.OleDb.OleDbType.VarWChar, 0, "Kassenzeichen"),
            new System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.VarWChar, 0, "Lieferant")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("EXT_ID", System.Data.OleDb.OleDbType.VarChar, 0, "EXT_ID"),
            new System.Data.OleDb.OleDbParameter("BARCODE", System.Data.OleDb.OleDbType.VarChar, 0, "BARCODE"),
            new System.Data.OleDb.OleDbParameter("Zulassungsnummer", System.Data.OleDb.OleDbType.VarChar, 0, "Zulassungsnummer"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("LangText", System.Data.OleDb.OleDbType.LongVarChar, 0, "LangText"),
            new System.Data.OleDb.OleDbParameter("Einheit", System.Data.OleDb.OleDbType.VarChar, 0, "Einheit"),
            new System.Data.OleDb.OleDbParameter("Gruppe", System.Data.OleDb.OleDbType.VarChar, 0, "Gruppe"),
            new System.Data.OleDb.OleDbParameter("Herrichten", System.Data.OleDb.OleDbType.Integer, 0, "Herrichten"),
            new System.Data.OleDb.OleDbParameter("AerztlichevorbereitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "AerztlichevorbereitungJN"),
            new System.Data.OleDb.OleDbParameter("Verabreichungsart", System.Data.OleDb.OleDbType.Integer, 0, "Verabreichungsart"),
            new System.Data.OleDb.OleDbParameter("Applikationsform", System.Data.OleDb.OleDbType.VarChar, 0, "Applikationsform"),
            new System.Data.OleDb.OleDbParameter("Packungsgroesse", System.Data.OleDb.OleDbType.Double, 0, "Packungsgroesse"),
            new System.Data.OleDb.OleDbParameter("Packungsanzahl", System.Data.OleDb.OleDbType.Integer, 0, "Packungsanzahl"),
            new System.Data.OleDb.OleDbParameter("Packungseinheit", System.Data.OleDb.OleDbType.VarChar, 0, "Packungseinheit"),
            new System.Data.OleDb.OleDbParameter("Gültigkeitsdatum", System.Data.OleDb.OleDbType.Date, 16, "Gültigkeitsdatum"),
            new System.Data.OleDb.OleDbParameter("Lagervorschrift", System.Data.OleDb.OleDbType.VarWChar, 0, "Lagervorschrift"),
            new System.Data.OleDb.OleDbParameter("ImportiertAm", System.Data.OleDb.OleDbType.Date, 16, "ImportiertAm"),
            new System.Data.OleDb.OleDbParameter("Importiert", System.Data.OleDb.OleDbType.Boolean, 0, "Importiert"),
            new System.Data.OleDb.OleDbParameter("Aktuell", System.Data.OleDb.OleDbType.Boolean, 0, "Aktuell"),
            new System.Data.OleDb.OleDbParameter("Erstattungscode", System.Data.OleDb.OleDbType.VarWChar, 0, "Erstattungscode"),
            new System.Data.OleDb.OleDbParameter("Kassenzeichen", System.Data.OleDb.OleDbType.VarWChar, 0, "Kassenzeichen"),
            new System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.VarWChar, 0, "Lieferant"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daMedikament2
            // 
            this.daMedikament2.DeleteCommand = this.oleDbCommand1;
            this.daMedikament2.InsertCommand = this.oleDbInsertCommand;
            this.daMedikament2.SelectCommand = this.oleDbCommand3;
            this.daMedikament2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Medikament", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("EXT_ID", "EXT_ID"),
                        new System.Data.Common.DataColumnMapping("BARCODE", "BARCODE"),
                        new System.Data.Common.DataColumnMapping("Zulassungsnummer", "Zulassungsnummer"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("LangText", "LangText"),
                        new System.Data.Common.DataColumnMapping("Einheit", "Einheit"),
                        new System.Data.Common.DataColumnMapping("Gruppe", "Gruppe"),
                        new System.Data.Common.DataColumnMapping("Herrichten", "Herrichten"),
                        new System.Data.Common.DataColumnMapping("AerztlichevorbereitungJN", "AerztlichevorbereitungJN"),
                        new System.Data.Common.DataColumnMapping("Verabreichungsart", "Verabreichungsart"),
                        new System.Data.Common.DataColumnMapping("Applikationsform", "Applikationsform"),
                        new System.Data.Common.DataColumnMapping("Packungsgroesse", "Packungsgroesse"),
                        new System.Data.Common.DataColumnMapping("Packungsanzahl", "Packungsanzahl"),
                        new System.Data.Common.DataColumnMapping("Packungseinheit", "Packungseinheit"),
                        new System.Data.Common.DataColumnMapping("Gültigkeitsdatum", "Gültigkeitsdatum"),
                        new System.Data.Common.DataColumnMapping("Lagervorschrift", "Lagervorschrift"),
                        new System.Data.Common.DataColumnMapping("ImportiertAm", "ImportiertAm"),
                        new System.Data.Common.DataColumnMapping("Importiert", "Importiert"),
                        new System.Data.Common.DataColumnMapping("Aktuell", "Aktuell"),
                        new System.Data.Common.DataColumnMapping("Erstattungscode", "Erstattungscode"),
                        new System.Data.Common.DataColumnMapping("Kassenzeichen", "Kassenzeichen"),
                        new System.Data.Common.DataColumnMapping("Lieferant", "Lieferant")})});
            this.daMedikament2.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [Medikament] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = resources.GetString("oleDbInsertCommand.CommandText");
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("EXT_ID", System.Data.OleDb.OleDbType.VarChar, 0, "EXT_ID"),
            new System.Data.OleDb.OleDbParameter("BARCODE", System.Data.OleDb.OleDbType.VarChar, 0, "BARCODE"),
            new System.Data.OleDb.OleDbParameter("Zulassungsnummer", System.Data.OleDb.OleDbType.VarChar, 0, "Zulassungsnummer"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("LangText", System.Data.OleDb.OleDbType.LongVarChar, 0, "LangText"),
            new System.Data.OleDb.OleDbParameter("Einheit", System.Data.OleDb.OleDbType.VarChar, 0, "Einheit"),
            new System.Data.OleDb.OleDbParameter("Gruppe", System.Data.OleDb.OleDbType.VarChar, 0, "Gruppe"),
            new System.Data.OleDb.OleDbParameter("Herrichten", System.Data.OleDb.OleDbType.Integer, 0, "Herrichten"),
            new System.Data.OleDb.OleDbParameter("AerztlichevorbereitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "AerztlichevorbereitungJN"),
            new System.Data.OleDb.OleDbParameter("Verabreichungsart", System.Data.OleDb.OleDbType.Integer, 0, "Verabreichungsart"),
            new System.Data.OleDb.OleDbParameter("Applikationsform", System.Data.OleDb.OleDbType.VarChar, 0, "Applikationsform"),
            new System.Data.OleDb.OleDbParameter("Packungsgroesse", System.Data.OleDb.OleDbType.Double, 0, "Packungsgroesse"),
            new System.Data.OleDb.OleDbParameter("Packungsanzahl", System.Data.OleDb.OleDbType.Integer, 0, "Packungsanzahl"),
            new System.Data.OleDb.OleDbParameter("Packungseinheit", System.Data.OleDb.OleDbType.VarChar, 0, "Packungseinheit"),
            new System.Data.OleDb.OleDbParameter("Gültigkeitsdatum", System.Data.OleDb.OleDbType.Date, 16, "Gültigkeitsdatum"),
            new System.Data.OleDb.OleDbParameter("Lagervorschrift", System.Data.OleDb.OleDbType.VarWChar, 0, "Lagervorschrift"),
            new System.Data.OleDb.OleDbParameter("ImportiertAm", System.Data.OleDb.OleDbType.Date, 16, "ImportiertAm"),
            new System.Data.OleDb.OleDbParameter("Importiert", System.Data.OleDb.OleDbType.Boolean, 0, "Importiert"),
            new System.Data.OleDb.OleDbParameter("Aktuell", System.Data.OleDb.OleDbType.Boolean, 0, "Aktuell"),
            new System.Data.OleDb.OleDbParameter("Erstattungscode", System.Data.OleDb.OleDbType.VarWChar, 0, "Erstattungscode"),
            new System.Data.OleDb.OleDbParameter("Kassenzeichen", System.Data.OleDb.OleDbType.VarWChar, 0, "Kassenzeichen"),
            new System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.VarWChar, 0, "Lieferant")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("EXT_ID", System.Data.OleDb.OleDbType.VarChar, 0, "EXT_ID"),
            new System.Data.OleDb.OleDbParameter("BARCODE", System.Data.OleDb.OleDbType.VarChar, 0, "BARCODE"),
            new System.Data.OleDb.OleDbParameter("Zulassungsnummer", System.Data.OleDb.OleDbType.VarChar, 0, "Zulassungsnummer"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("LangText", System.Data.OleDb.OleDbType.LongVarChar, 0, "LangText"),
            new System.Data.OleDb.OleDbParameter("Einheit", System.Data.OleDb.OleDbType.VarChar, 0, "Einheit"),
            new System.Data.OleDb.OleDbParameter("Gruppe", System.Data.OleDb.OleDbType.VarChar, 0, "Gruppe"),
            new System.Data.OleDb.OleDbParameter("Herrichten", System.Data.OleDb.OleDbType.Integer, 0, "Herrichten"),
            new System.Data.OleDb.OleDbParameter("AerztlichevorbereitungJN", System.Data.OleDb.OleDbType.Boolean, 0, "AerztlichevorbereitungJN"),
            new System.Data.OleDb.OleDbParameter("Verabreichungsart", System.Data.OleDb.OleDbType.Integer, 0, "Verabreichungsart"),
            new System.Data.OleDb.OleDbParameter("Applikationsform", System.Data.OleDb.OleDbType.VarChar, 0, "Applikationsform"),
            new System.Data.OleDb.OleDbParameter("Packungsgroesse", System.Data.OleDb.OleDbType.Double, 0, "Packungsgroesse"),
            new System.Data.OleDb.OleDbParameter("Packungsanzahl", System.Data.OleDb.OleDbType.Integer, 0, "Packungsanzahl"),
            new System.Data.OleDb.OleDbParameter("Packungseinheit", System.Data.OleDb.OleDbType.VarChar, 0, "Packungseinheit"),
            new System.Data.OleDb.OleDbParameter("Gültigkeitsdatum", System.Data.OleDb.OleDbType.Date, 16, "Gültigkeitsdatum"),
            new System.Data.OleDb.OleDbParameter("Lagervorschrift", System.Data.OleDb.OleDbType.VarWChar, 0, "Lagervorschrift"),
            new System.Data.OleDb.OleDbParameter("ImportiertAm", System.Data.OleDb.OleDbType.Date, 16, "ImportiertAm"),
            new System.Data.OleDb.OleDbParameter("Importiert", System.Data.OleDb.OleDbType.Boolean, 0, "Importiert"),
            new System.Data.OleDb.OleDbParameter("Aktuell", System.Data.OleDb.OleDbType.Boolean, 0, "Aktuell"),
            new System.Data.OleDb.OleDbParameter("Erstattungscode", System.Data.OleDb.OleDbType.VarWChar, 0, "Erstattungscode"),
            new System.Data.OleDb.OleDbParameter("Kassenzeichen", System.Data.OleDb.OleDbType.VarWChar, 0, "Kassenzeichen"),
            new System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.VarWChar, 0, "Lieferant"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daMedikamentSmall
            // 
            this.daMedikamentSmall.SelectCommand = this.oleDbCommand7;
            this.daMedikamentSmall.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Medikament", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Aktuell", "Aktuell")})});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = "SELECT        ID, Bezeichnung + \' (\' + CONVERT(varchar(50), Packungsgroesse) + \' " +
    "\' + Packungseinheit + \')\' AS Bezeichnung, Aktuell\r\nFROM            Medikament";
            this.oleDbCommand7.Connection = this.oleDbConnection1;
            // 
            // dsMedikament1
            // 
            this.dsMedikament1.DataSetName = "dsMedikament";
            this.dsMedikament1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsMedikament1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsMedikament1)).EndInit();

		}
		#endregion
	}
}
