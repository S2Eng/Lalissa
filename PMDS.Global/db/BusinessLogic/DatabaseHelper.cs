using System;
using PMDS.Global;
using PMDS.Data.Global;
using System.Data.OleDb;
using RBU;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{


    public class DatabaseHelper
    {




        public static dsGuidListeNoKey.IDListeDataTable IDListeFromSQL(string sSQL)
        {
            try
            {
                dsGuidListeNoKey.IDListeDataTable dt = new dsGuidListeNoKey.IDListeDataTable();
                OleDbCommand cmd = new OleDbCommand(sSQL);
                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                
                foreach (System.Data.DataRow r in dtSelect.Rows)
                {
                    if (r[0] != System.DBNull.Value)
                    {
                        bool bGuidOK = false;
                        Nullable<Guid> idGuid = null;
                        try
                        {
                            idGuid = new Guid(r[0].ToString());
                            bGuidOK = true;
                        }
                        catch (Exception ex)
                        {
                            string sExcept = "DatabaseHelper.IDListeFromSQL - Error convert r[0].ToGuid() r[0]='" + r[0].ToString() + "' : Command =" + sSQL + "\r\n" + "\r\n" + ex.ToString();
                            Exception ex2 = new Exception(sExcept);
                            PMDS.Global.ENV.HandleException(ex2);
                            //PMDS.Global.ENV.WriteLog(sExcept);
                        }

                        if (bGuidOK)
                        {
                            string sTxt = "";
                            if (r[1] != System.DBNull.Value)
                            {
                                sTxt = r[1].ToString();
                            }
                            dt.AddIDListeRow(idGuid.Value, sTxt);
                        }
                    }
                }
                dt.AcceptChanges();
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception("DatabaseHelper.IDListeFromSQL2: Command =" + sSQL + " / " + ex.ToString());
            }
        }

        public static bool BooleanFromSQL(string sSQL)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(sSQL);
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
                        int iVal = System.Convert.ToInt32(r[0]);
                        return iVal == 0 ? false : true;
                    }
                }
                return false;

            }
            catch (Exception ex) 
            {
                Exception e = new Exception("Bei der Verarbeitung von BooleanFromSQL ist ein Fehler aufgetreten\r\n" + sSQL, ex);
                ENV.HandleException(e);
                return false;
            }
        }


        public static string TextFromSQL(string sSQL)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(sSQL);
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
                        return r[0].ToString().Trim();
                    }
                }

                return "";

            }
            catch (Exception ex) 
            {
                Exception e = new Exception("Bei der Verarbeitung von BooleanFromSQL ist ein Fehler aufgetreten\r\n" + sSQL, ex);
                ENV.HandleException(e);
                return "";
            }
        }
    }
}
