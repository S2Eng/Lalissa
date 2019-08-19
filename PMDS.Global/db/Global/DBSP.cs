//----------------------------------------------------------------------------
/// <summary>
///	DBSP.cs
/// Erstellt am:	12.12.2007
/// Erstellt von:	RBU
/// 
/// Zugriffsklasse für Standardprozeduren
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data.OleDb;
using PMDS.Global;

using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;

namespace PMDS.DB.Global
{
    public partial class DBSP : Component
    {
        private OleDbCommand _cmdOpenFromPatient = null;

        public DBSP()
        {
            InitializeComponent();

        }

        public DBSP(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public dsSP Read(Guid IDSP)
        {
            dsSP ds = new dsSP();
            daSP.SelectCommand.Parameters[0].Value = IDSP;
            DataBase.Fill(daSP, ds);

            daSPPOS.SelectCommand.Parameters[0].Value = IDSP;
            DataBase.Fill(daSPPOS, ds);

            return ds;
        }

        public void Write(dsSP ds)
        {
            DataBase.Update(daSP,       ds.SP);
            DataBase.Update(daSPPOS,    ds.SPPOS);
            DataBase.Update(daSPPE,     ds.SPPE);
        }

        public dsSP.SPDataTable ReadAllOpen(Guid IDAufenthalt)
        {
            dsSP.SPDataTable dt = new dsSP.SPDataTable();
            daSP_open.SelectCommand.Parameters[0].Value = IDAufenthalt;
            DataBase.Fill(daSP_open, dt);
            return dt;
        }

        public bool HasOpenFromAufenthalt(Guid IDAufenthalt)
        {
            try
            {
                bool bRet = false;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "Select ID from SP where IDAufenthalt = ? and offenJN = 1";
                cmd.Parameters.AddWithValue("IDA", IDAufenthalt);
                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    System.Data.DataRow r = dtSelect.Rows[0];
                    bRet = true;
                }

                return bRet;

            }
            catch (Exception ex)
            {
                throw new Exception("HasOpenFromAufenthalt: " + ex.ToString());
            }
        }

        public bool HasOpenFromPatient(Guid IDPatient)
        {
            bool bRet = false;
            System.Data.DataTable t = new System.Data.DataTable();

            OleDbDataAdapter da = new OleDbDataAdapter();
            System.Data.OleDb.OleDbCommand selCmd = new    System.Data.OleDb.OleDbCommand();
            selCmd.CommandText = "SELECT SP.ID FROM Aufenthalt INNER JOIN Patient ON Aufenthalt.IDPatient = Patient.ID " +
                                    " INNER JOIN SP ON Aufenthalt.ID = SP.IDAufenthalt WHERE (Patient.ID = '" + IDPatient.ToString () + "') AND (SP.offenJN = 1)";
            da.SelectCommand = selCmd;
            DataBase.Fill(da, t);
            if (t.Rows .Count  > 0 )
                bRet = true;

            return bRet;
        }

        public static List<SPNextHelper> AllOpenSPPos(Guid IDSP)
        {
            try
            {
                List<SPNextHelper> al = new List<SPNextHelper>();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT SPPOS.wiederumam, Eintrag.Text FROM SPPOS INNER JOIN SP ON SPPOS.IDSP = SP.ID INNER JOIN Eintrag ON SPPOS.IDEintrag = Eintrag.ID WHERE (SP.ID = ?) AND (SP.offenJN = 1) AND (NOT (SPPOS.wiederumam IS NULL))ORDER BY SPPOS.wiederumam";
                cmd.Parameters.AddWithValue("ID", IDSP);
                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                foreach (System.Data.DataRow r in dtSelect.Rows)
                {
                    DateTime datTmp = (DateTime)r[0];
                    al.Add(new SPNextHelper(datTmp, r[1].ToString().Trim()));
                }

                return al;

            }
            catch (Exception ex)
            {
                throw new Exception("AllOpenSPPos: " + ex.ToString());
            }
        }

    }

    

}
