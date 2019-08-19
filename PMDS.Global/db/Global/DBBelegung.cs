//----------------------------------------------------------------------------
/// <summary>
///	Zugriffsklasse Belegung
/// 2.6.2008   erstellt RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data.OleDb;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;

namespace PMDS.DB.Global
{
    public partial class DBBelegung : Component
    {
        public static OleDbCommand _cmdAnzahlBetten;
        public static OleDbCommand _cmdAnzahlAufenthalt;
        public static OleDbCommand _cmdAnzahlUrlaube; 

        public DBBelegung()
        {
            InitializeComponent();
        }

        public DBBelegung(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Lesen
        /// </summary>
        //----------------------------------------------------------------------------
        public dsBelegung.BelegungDataTable Read(Guid IDAbteilung, DateTime von, DateTime bis)
        {
            dsBelegung.BelegungDataTable dt = new dsBelegung.BelegungDataTable();
            daBelegung.SelectCommand.Parameters[0].Value = IDAbteilung;
            daBelegung.SelectCommand.Parameters[1].Value = von;
            daBelegung.SelectCommand.Parameters[2].Value = bis;
            DataBase.Fill(daBelegung, dt);
            return dt;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Festschreiben
        /// </summary>
        //----------------------------------------------------------------------------
        public void Write(dsBelegung.BelegungDataTable dt)
        {
            // Wenn sich die Bettenbelegung ändert muß für die Reports die Information in der Essens
            // Tabelle nachgezogen werden - diese würden erst über die GUI aktualisiert werden
            foreach (dsBelegung.BelegungRow r in dt)
            {
                if (r.RowState != System.Data.DataRowState.Modified)
                    continue;

            }
            DataBase.Update(daBelegung, dt);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert die Anzahl der verfügbaren Betten eines Tages
        /// </summary>
        //----------------------------------------------------------------------------
        public static int AnzahlBettenTag(DateTime dtDay)
        {
            InitCommandAnzahlBetten();
            _cmdAnzahlBetten.Parameters[0].Value = dtDay.Date;
            int iAnzahl = GetColumn0Int(_cmdAnzahlBetten);
            return iAnzahl;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        ///	Ermittelt die Belegung des Tages aus den Aufenthalten und dem Urlaubsverlauf
        /// Der Urlaubsbeginn gilt als abwesend, das urlaubsende als anwesend
        /// </summary>
        //----------------------------------------------------------------------------
        public static void BelegungTag(DateTime dtday, out int iBelegung, out int iUrlaube)
        {
            InitCommandAnzahlAufenthalt();
            InitCommandAnzahlUrlaube();
            iBelegung = 0;
            iUrlaube = 0;

            // Alle Aufenthalte des Tages
            _cmdAnzahlAufenthalt.Parameters[0].Value = dtday.Date;
            _cmdAnzahlAufenthalt.Parameters[1].Value = dtday.Date;
            _cmdAnzahlAufenthalt.Parameters[2].Value = dtday.Date;
            iBelegung = GetColumn0Int(_cmdAnzahlAufenthalt);
            
            // Alle Urlaube des Tages
            _cmdAnzahlUrlaube.Parameters[0].Value = dtday.Date;
            _cmdAnzahlUrlaube.Parameters[1].Value = dtday.Date;
            _cmdAnzahlUrlaube.Parameters[2].Value = dtday.Date;  
            iUrlaube = GetColumn0Int(_cmdAnzahlUrlaube);

            iBelegung -= iUrlaube;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert den Integer Wert der Spalte 0
        /// </summary>
        //----------------------------------------------------------------------------
        private static int GetColumn0Int(OleDbCommand cmd)
        {
            try
            {
                int iRet = 0;
                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    System.Data.DataRow r = dtSelect.Rows[0];
                    if (r[0] != System.DBNull.Value)
                    {
                        iRet = System.Convert.ToInt32(r[0].ToString().Trim());
                    }
                }

                return iRet;

            }
            catch (Exception ex)
            {
                throw new Exception("GetColumn0Int: " + ex.ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Command Initialisierung
        /// </summary>
        //----------------------------------------------------------------------------
        private static void InitCommandAnzahlAufenthalt()
        {
            if (_cmdAnzahlAufenthalt != null)
                return;
            _cmdAnzahlAufenthalt = new OleDbCommand();
            _cmdAnzahlAufenthalt.CommandText = "select count(*) from Aufenthalt where (CAST(FLOOR(CAST(AufnahmeZeitpunkt AS FLOAT)) AS DATETIME) <= ? and Entlassungszeitpunkt is null) or (CAST(FLOOR(CAST(AufnahmeZeitpunkt AS FLOAT)) AS DATETIME) <= ? and CAST(FLOOR(CAST(Entlassungszeitpunkt AS FLOAT)) AS DATETIME) > ?)";
            _cmdAnzahlAufenthalt.Parameters.Add("Tag", OleDbType.Date);
            _cmdAnzahlAufenthalt.Parameters.Add("Tag2", OleDbType.Date);
            _cmdAnzahlAufenthalt.Parameters.Add("Tag3", OleDbType.Date);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Command Initialisierung
        /// </summary>
        //----------------------------------------------------------------------------
        private static void InitCommandAnzahlUrlaube()
        {
            if (_cmdAnzahlUrlaube != null)
                return;
            _cmdAnzahlUrlaube = new OleDbCommand();
            _cmdAnzahlUrlaube.CommandText = "select count(*) from Urlaubverlauf where (CAST(FLOOR(CAST(StartDatum AS FLOAT)) AS DATETIME) <= ? and CAST(FLOOR(CAST(EndeDatum AS FLOAT)) AS DATETIME) is null) or (CAST(FLOOR(CAST(StartDatum AS FLOAT)) AS DATETIME)<= ? and CAST(FLOOR(CAST(Endedatum AS FLOAT)) AS DATETIME) > ?)";
            _cmdAnzahlUrlaube.Parameters.Add("Tag", OleDbType.Date);
            _cmdAnzahlUrlaube.Parameters.Add("Tag2", OleDbType.Date);
            _cmdAnzahlUrlaube.Parameters.Add("Tag3", OleDbType.Date);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Command Initialisierung
        /// </summary>
        //----------------------------------------------------------------------------
        private static void InitCommandAnzahlBetten()
        {
            if(_cmdAnzahlBetten != null)
             return;

            _cmdAnzahlBetten = new OleDbCommand();
            _cmdAnzahlBetten.CommandText = "Select sum(Anzahlbetten) from Belegung where Tag = ?";
            _cmdAnzahlBetten.Parameters.Add("Tag", OleDbType.Date);
        }
    }
}
