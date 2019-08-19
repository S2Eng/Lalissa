using RBU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace PMDS.Global
{
    
    public class dbBase
    {



        public static System.Data.OleDb.OleDbConnection getConn()
        {
            try
            {
                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(RBU.DataBase.ConnStr);
                //System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(RBU.DataBase.CONNECTION.ConnectionString);

                conn.Open();
                return conn;

            }
            catch (Exception ex)
            {
                throw new Exception("getConn: " + ex.ToString());
            }
        }

        public static void setConnection(System.Data.OleDb.OleDbDataAdapter da, System.Data.OleDb.OleDbConnection conn)
        {
            if (da.SelectCommand != null)
                da.SelectCommand.Connection = conn;
            if (da.InsertCommand != null)
                da.InsertCommand.Connection = conn;
            if (da.UpdateCommand != null)
                da.UpdateCommand.Connection = conn;
            if (da.DeleteCommand != null)
                da.DeleteCommand.Connection = conn;
        }
        public static void setConnection2(System.Data.SqlClient.SqlDataAdapter da, System.Data.SqlClient.SqlConnection conn)
        {
            if (da.SelectCommand != null)
                da.SelectCommand.Connection = conn;
            if (da.InsertCommand != null)
                da.InsertCommand.Connection = conn;
            if (da.UpdateCommand != null)
                da.UpdateCommand.Connection = conn;
            if (da.DeleteCommand != null)
                da.DeleteCommand.Connection = conn;
        }
    }
}
