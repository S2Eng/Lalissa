using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Data.Global;
using System.Data.OleDb;
using RBU;
using PMDS.Global.db.Global;


namespace PMDS.DB.Global
{
    public partial class DBMedikation : Component
    {

        private static OleDbCommand _cmdSelect = null;
        private static OleDbCommand _cmdInsert = null;




        public DBMedikation()
        {
            InitializeComponent();
        }

        public DBMedikation(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }



        public static AbgegebenHelper IsAbgegeben(Guid IDRezeptEintrag, DateTime dt)
        {
            try
            {
                InitCommands();
                _cmdSelect.Parameters[0].Value = IDRezeptEintrag;
                _cmdSelect.Parameters[1].Value = dt;

                AbgegebenHelper h = new AbgegebenHelper();
                _cmdSelect.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = _cmdSelect;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    System.Data.DataRow r = dtSelect.Rows[0];
                    h._IsAbgegeben = true;
                    string AbgegebenVonTmp = "";
                    if (r[0] != System.DBNull.Value)
                    {
                        AbgegebenVonTmp = r[0].ToString().Trim();
                    }
                    h._AbgegebenVon = AbgegebenVonTmp.Trim();
                    return h;
                }

                return h;
            }
            catch (Exception ex)
            {
                throw new Exception("DBMedikation.IsAbgegeben: " + ex.ToString());
            }
        }

        public static void InsertMedikationAbgabe(Guid IDRezeptEintrag, DateTime dt, Guid IDBenutzer, string MedikamentText, Guid IDaufenthalt, bool TagesspenderJN, Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = DateTime.Now;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                InitCommands();

                _cmdInsert.Parameters[0].Value = IDRezeptEintrag;
                _cmdInsert.Parameters[1].Value = dt;
                _cmdInsert.Parameters[2].Value = IDBenutzer;
                _cmdInsert.Parameters[3].Value = MedikamentText;
                _cmdInsert.Parameters[4].Value = IDaufenthalt;
                _cmdInsert.Parameters[5].Value = TagesspenderJN;

                DataBase.EcecuteNonQuery(_cmdInsert);
            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "DBMedikation.InsertMedikationAbgabe"))
                {
                    DBMedikation.InsertMedikationAbgabe(IDRezeptEintrag, dt, IDBenutzer, MedikamentText, IDaufenthalt, TagesspenderJN, IDTime);
                }
                throw new Exception("DBMedikation.InsertMedikationAbgabe: " + ex.ToString());
            }
        }

        private static void InitCommands()
        {
            if (_cmdSelect != null)
                return;

            _cmdSelect = new OleDbCommand();
            _cmdInsert = new OleDbCommand();

            _cmdSelect.CommandText = "SELECT Benutzer.Benutzer FROM MedikationAbgabe LEFT OUTER JOIN Benutzer ON MedikationAbgabe.IDBenutzer = Benutzer.ID where IDRezepteintrag = ? and Zeitpunkt = ?";
            _cmdSelect.Parameters.Add("IDRezepteintrag", OleDbType.Guid);
            _cmdSelect.Parameters.Add("Zeitpunkt", OleDbType.DBTimeStamp);

            _cmdInsert.CommandText = "insert into MedikationAbgabe (IDRezepteintrag, Zeitpunkt, IDBenutzer, MedikamentText, IDAufenthalt, TagesspenderJN) values(?,?,?,?,?,?)";
            _cmdInsert.Parameters.Add("IDRezepteintrag", OleDbType.Guid);
            _cmdInsert.Parameters.Add("Zeitpunkt", OleDbType.DBTimeStamp);
            _cmdInsert.Parameters.Add("IDBenutzer", OleDbType.Guid);
            _cmdInsert.Parameters.Add("MedikamentText", OleDbType.VarChar);
            _cmdInsert.Parameters.Add("IDAufenthalt", OleDbType.Guid);
            _cmdInsert.Parameters.Add("TagesspenderJN", OleDbType.Boolean);

        }

        public dsMedikationVonBis.MedikationDataTable Read(DateTime dtvon, DateTime dtbis, Guid IDAufenthalt)
        {
            string sOld = daMedikationVonBis.SelectCommand.CommandText;
            try
            {
                daMedikationVonBis.SelectCommand.CommandText += " where RezeptEintrag.IDAufenthalt = ? and not ((AbzugebenVon < ? and AbzugebenBis < ?) or AbzugebenVon > ?)";
                dsMedikationVonBis.MedikationDataTable dt = new dsMedikationVonBis.MedikationDataTable();
                daMedikationVonBis.SelectCommand.Parameters.Clear();
                daMedikationVonBis.SelectCommand.Parameters.AddWithValue("IDAufenthalt", IDAufenthalt);
                daMedikationVonBis.SelectCommand.Parameters.AddWithValue("v1", dtvon);
                daMedikationVonBis.SelectCommand.Parameters.AddWithValue("v2", dtvon);
                daMedikationVonBis.SelectCommand.Parameters.AddWithValue("v3", dtbis);
                DataBase.Fill(daMedikationVonBis, dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception("DBMedikation.Read: " + ex.ToString());
            }
            finally
            {
                daMedikationVonBis.SelectCommand.CommandText = sOld;
            }
        }

        private void daMedikationVonBis_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {

        }
    }
}
