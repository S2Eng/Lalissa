using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data.OleDb;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global.ds_abrechnung;





namespace PMDS.DB.Global
{
    //----------------------------------------------------------------------------
    /// <summary>
    /// Zugriff und speicherung auf die MedizinischenDaten
    /// </summary>
    //----------------------------------------------------------------------------
    public partial class DBManBuchungen : Component
    {
        public DBManBuchungen()
        {
            InitializeComponent();
        }

        public DBManBuchungen(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void allManBuchungen(dsManBuch ds , Guid IDPatient, object von, object bis, bool abgerechJN, 
                                    PMDS.Calc.Logic.eCalcRun  typ, string orderBy, Guid IDKlinik)
        {
            DateTime dVon = new DateTime (1920, 1, 1);
            DateTime dBis =  new DateTime (2200, 12, 31);
            if (von != null) dVon = (DateTime)von;
            if (bis != null)
            {
               DateTime dHelp = (DateTime)bis;
               dBis = new DateTime(dHelp.Year, dHelp.Month, dHelp.Day, 23, 59, 59);
            }

            this.daManBuchugenIDKlient.SelectCommand.CommandText = " SELECT ID, datum, ReNr, abrechGruppe, gruppeTxt, " +
                            " IDRef, betrag, MwSt, brutto, buchText, IDKlient, abgerechJN, abgerechAm, " +
                            " erfasst, am, Zeitraumdetail, typ, " +
                            " RechnungTyp, IDKlinik, FIBUKonto " +
                            " FROM            manBuch " +
                            " WHERE        (IDKlient = ?) AND (datum >= ?) AND (datum <= ?) AND (abgerechJN = ? OR " +
                            " abgerechJN = ?) AND Typ = ? and IDKlinik = ? ";
            
            this.daManBuchugenIDKlient.SelectCommand.Parameters[0].Value = IDPatient;
            daManBuchugenIDKlient.SelectCommand.Parameters[1].Value = dVon;
            daManBuchugenIDKlient.SelectCommand.Parameters[2].Value = dBis;
            if (abgerechJN)
            {
                daManBuchugenIDKlient.SelectCommand.Parameters[3].Value = abgerechJN;
                daManBuchugenIDKlient.SelectCommand.Parameters[4].Value = abgerechJN;
            }
            else
            {
                daManBuchugenIDKlient.SelectCommand.Parameters[3].Value = true;
                daManBuchugenIDKlient.SelectCommand.Parameters[4].Value = false;
            }
            daManBuchugenIDKlient.SelectCommand.Parameters[5].Value = (int )typ;
            daManBuchugenIDKlient.SelectCommand.Parameters[6].Value = IDKlinik;

            daManBuchugenIDKlient.SelectCommand.CommandText += orderBy;

            DataBase.Fill(daManBuchugenIDKlient, ds);
        }
        public dsManBuch readManBuchungen(  Guid ID)
        {
            dsManBuch dsManBuch = new dsManBuch();
            this.daManBuchugenID.SelectCommand.Parameters[0].Value = ID;
            DataBase.Fill(daManBuchugenID, dsManBuch);
            return dsManBuch;
        }

        
        public dsAlleKostFürKlient   allKostFürPatient(  Guid IDPatient )
        {
            dsAlleKostFürKlient ds = new dsAlleKostFürKlient();
            this.daIDAlleKostFürKlient .SelectCommand.Parameters[0].Value = IDPatient;
            this.daIDAlleKostFürKlient.SelectCommand.Parameters[1].Value = IDPatient;
            DataBase.Fill(daIDAlleKostFürKlient, ds);
            return ds;
        }

        public void Update(dsManBuch  ds)
        {
            DataBase.Update(daManBuchugenIDKlient, ds);
        }

        public bool updManBuch(dsManBuch dsManBuch, object  abrechDat, DBManBuchungen _db, bool abgerechJN)
        {
            foreach (PMDS.Global.db.Global.ds_abrechnung.dsManBuch.manBuchRow rManBuch in dsManBuch.manBuch.Rows)
                {
                    rManBuch.abgerechJN = abgerechJN;
                    if (abrechDat == null)
                    {
                        rManBuch.IsabgerechAmNull();
                        rManBuch.abgerechJN = false;
                        rManBuch.ReNr = "";
                    }
                    else
                    {
                        rManBuch.abgerechAm = (DateTime)abrechDat;
                        rManBuch.abgerechJN = abgerechJN;
                    }
                }
                _db.Update(dsManBuch);
                return true;

                //OleDbCommand cmd = new OleDbCommand();
                //cmd.Connection = RBU.DataBase.CONNECTION;
                //cmd.Transaction = _trans;
                //cmd.CommandText = "UPDATE  manBuch  SET  abgerechJN = ?, abgerechAm = ?  WHERE ID = ? ";
                //cmd.Parameters.Add("abgerechJN", System.Data.OleDb.OleDbType.Boolean, 1, "abgerechJN").Value = true;
                //cmd.Parameters.Add("abgerechAm", System.Data.OleDb.OleDbType.Date, 8, "abgerechAm").Value = abrechDat;
                //cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = rManBuch.ID;
                //cmd.ExecuteNonQuery();
                //trans.Commit();
        }

        public bool updManBuch_rechNr(dsManBuch dsManBuch, string ReNr, DBManBuchungen _db)
        {
            PMDS.Global.db.Global.ds_abrechnung.dsManBuch.manBuchRow rManBuch = (PMDS.Global.db.Global.ds_abrechnung.dsManBuch.manBuchRow)dsManBuch.manBuch.Rows[0];
            rManBuch.ReNr = ReNr;
            _db.Update(dsManBuch);
            return true;

        }
    }
}
