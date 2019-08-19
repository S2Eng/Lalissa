//----------------------------------------------------------------------------
/// <summary>
///	DBStandardProzeduren.cs
/// Erstellt am:	16.11.2007
/// Erstellt von:	RBU (übernommener Code MDA vom ????)
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Data.Global;
using RBU;
using System.Data;
using System.Data.OleDb;

namespace PMDS.DB.Global
{
    public partial class DBStandardProzeduren : Component
    {
        public DBStandardProzeduren()
        {
            InitializeComponent();
        }

        public DBStandardProzeduren(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert alle Standardprozeduren sowie die DynRep Verknüpfungen dazu
        /// Read muss vorher ausgeführt werden
        /// </summary>
        //----------------------------------------------------------------------------
        public dsStandardProzeduren ALL
        {
            get { return dsStandardProzeduren1; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// LIefert alle Standardprozeduren, die Einträge sowie die DynRep Verknüpfungen dazu
        /// </summary>
        //----------------------------------------------------------------------------
        public dsStandardProzeduren Read()
        {
            dsStandardProzeduren1.SPDynRep.Clear();
            dsStandardProzeduren1.StandardProzeduren.Rows.Clear();
            dsStandardProzeduren1.EintragStandardprozeduren.Rows.Clear();

            DataBase.Fill(daStandardProzeduren,         dsStandardProzeduren1.StandardProzeduren);
            DataBase.Fill(daSPDynRep,                   dsStandardProzeduren1.SPDynRep);
            DataBase.Fill(daEintragStandardprozeduren,  dsStandardProzeduren1.EintragStandardprozeduren);
            
            return dsStandardProzeduren1;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Erstellt einen neuen Eintrag in StandardProzeduren und liefert diese Row 
        /// als Referenz
        /// </summary>
        //----------------------------------------------------------------------------
        public dsStandardProzeduren.StandardProzedurenRow New()
        {
            dsStandardProzeduren.StandardProzedurenRow r = dsStandardProzeduren1.StandardProzeduren.NewStandardProzedurenRow();
            r.ID = Guid.NewGuid();
            r.Name = "";
            r.ShowPrintDialog = false;
            dsStandardProzeduren1.StandardProzeduren.AddStandardProzedurenRow(r);
            return r;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten gegen die DB Festschreiben, der Caller muss sich um eine evtl. Transaktion
        /// kümmern
        /// </summary>
        //----------------------------------------------------------------------------
        public void Write()
        {
            DataTable tINSUPDSPDynRep   = ALL.SPDynRep.GetChanges(DataRowState.Added | DataRowState.Modified);
            DataTable tDELSPDynRep      = ALL.SPDynRep.GetChanges(DataRowState.Deleted);

            DataTable tINSUPD_EintragSP = ALL.EintragStandardprozeduren.GetChanges(DataRowState.Added | DataRowState.Modified);
            DataTable tDEL_EintragSP    = ALL.EintragStandardprozeduren.GetChanges(DataRowState.Deleted);

            if(tDELSPDynRep != null)
                DataBase.Update(daSPDynRep, tDELSPDynRep);
            if (tDEL_EintragSP != null)
                DataBase.Update(daEintragStandardprozeduren, tDEL_EintragSP);

            DataBase.Update(daStandardProzeduren, dsStandardProzeduren1);
            
            if(tINSUPDSPDynRep != null)
                DataBase.Update(daSPDynRep, tINSUPDSPDynRep);
            if (tINSUPD_EintragSP != null)
                DataBase.Update(daEintragStandardprozeduren, tINSUPD_EintragSP);

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den verspeicherten Pfad der SP
        /// </summary>
        //----------------------------------------------------------------------------
        public static string GetReportPath(Guid IDStandardProzedur)
        {
            try
            {
                string sRet = "";
                OleDbCommand cmd = new OleDbCommand("select dynrep from SPDynRep where IDStandardProzeduren = ?");
                cmd.Parameters.AddWithValue("IDS", IDStandardProzedur);
                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    System.Data.DataRow r = dtSelect.Rows[0];
                    sRet = r[0].ToString();
                }

                return sRet;

            }
            catch (Exception ex)
            {
                throw new Exception("GetReportPath: " + ex.ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den Namen der SP
        /// </summary>
        //----------------------------------------------------------------------------
        public static string GetBezeichnung(Guid IDStandardProzedur)
        {
            try
            {
                string sRet = "";
                OleDbCommand cmd = new OleDbCommand("select name from standardprozeduren where ID = ?");
                cmd.Parameters.AddWithValue("ID", IDStandardProzedur);
                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    System.Data.DataRow r = dtSelect.Rows[0];
                    sRet = r[0].ToString();
                }

                return sRet;

            }
            catch (Exception ex)
            {
                throw new Exception("GetBezeichnung: " + ex.ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert das Notfallflag der SP
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool GetNotfallFlag(Guid IDStandardProzedur)
        {
            try
            {
                bool bRet = false;
                OleDbCommand cmd = new OleDbCommand("select NotfallJN from standardprozeduren where ID = ?");
                cmd.Parameters.AddWithValue("ID", IDStandardProzedur);
                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    System.Data.DataRow r = dtSelect.Rows[0];
                    bRet = (bool)r[0];
                }

                return bRet;

            }
            catch (Exception ex)
            {
                throw new Exception("GetNotfallFlag: " + ex.ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die SP vom Pflegeeintrag
        /// </summary>
        //----------------------------------------------------------------------------
        public static Guid GetIDSPfromIDPflegeEintrag(Guid IDPflegeEintrag)
        {
            return PMDS.DB.DBUtil.GetSPPE(IDPflegeEintrag).IDSP;
       }
    }
}
