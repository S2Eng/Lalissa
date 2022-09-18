using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace qs2.sitemap.queries
{

    public class dbKaplanMeier
    {

        public DataRow[] getInputListe(string IDParticipant,
                                        ref DataTable t)
        {
            string sWhere = "";
            string sOrderBy = "";
            //if (t.Columns.Contains(("IDParticipant").ToLower()))
            //{
            //string strTemp = "ParticID='" + IDParticipant + "'";
            //sWhere += (sWhere.Trim() == "" ? "" : " and ") + strTemp;
            //}
            //if (t.Columns.Contains(("fldFUP_Ereignis").ToLower()))
            //{
            //string strTemp2 = "fldFUP_Ereignis=" + Ereignis.ToString () + "";
            //sWhere += (sWhere.Trim() == "" ? "" : " and ") + strTemp2;
            //}

            //string strTempSubSelects = " ((vQTH_FollowUp.ID = (SELECT TOP (1) f.ID FROM vQTH_FollowUp AS f WHERE (f.FK_StayID = vQTH_Stays.ID) AND (f.fldFUP_Ereignis = {0} OR f.fldFUP_Ereignis = 3) ORDER BY fldFUP_DateInvestigation)) " +
            //                                    "OR (vQTH_FollowUp.ID = (SELECT TOP (1) ID FROM vQTH_FollowUp AS f WHERE (FK_StayID = vQTH_Stays.ID) AND (fldFUP_Ereignis = 0) AND ((SELECT Count(*) FROM vQTH_FollowUp AS f1 WHERE (f1.FK_StayID = vQTH_Stays.ID) AND ((f1.fldFUP_Ereignis <> -1) AND (f1.fldFUP_Ereignis <> 0))) = 0) ORDER BY fldFUP_DateInvestigation DESC))) ";
            //strTempSubSelects = String.Format(strTempSubSelects, Ereignis.ToString());
            //sWhere += (sWhere.Trim() == "" ? "" : " and ") + strTempSubSelects;

            DataRow[] arrRows = (System.Data.DataRow[])t.Select(sWhere, sOrderBy);
            return arrRows;
        }

        public DataTable getInputListe_orig(int Ereignis, DateTime startDat, DateTime endDat, string IDParticipant)
        {

            DataTable rs = new DataTable();
            string sql;

            String sDat = string.Format("{0:D4}", startDat.Year) + "-" + string.Format("{0:D2}", startDat.Month) + "-" + string.Format("{0:D2}", startDat.Day) + " " + string.Format("{0:D2}", startDat.Hour) + ":" + string.Format("{0:D2}", startDat.Minute) + ":" + string.Format("{0:D2}", startDat.Second);
            String eDat = string.Format("{0:D4}", endDat.Year) + "-" + string.Format("{0:D2}", endDat.Month) + "-" + string.Format("{0:D2}", endDat.Day) + " " + string.Format("{0:D2}", endDat.Hour) + ":" + string.Format("{0:D2}", endDat.Minute) + ":" + string.Format("{0:D2}", endDat.Second);

            sql = string.Format("SELECT tblPatient.ExtPatID, tblPatient.Firstname, tblPatient.Lastname, tblPatient.DOB, tblStays.ID, tblStays.RecID, tblStays.MedRecNum, tblStays.Ist_OPDatum, " +
                                        "tblFollowUp.fldFUP_DateInvestigation, tblFollowUp.fldFUP_Ereignis " +
                                "FROM    tblStays INNER JOIN " +
                                        "tblPatient ON tblStays.PatID = tblPatient.ID INNER JOIN " +
                                        "tblFollowUp ON tblStays.ID = tblFollowUp.FK_StayID " +
                                "WHERE  (tblStays.Ist_OPDatum > CONVERT(DATETIME, '{0}', 102)) AND (tblStays.Ist_OPDatum < CONVERT(DATETIME, '{1}', 102)) " +
                                        "AND (tblFollowUp.fldFUP_DateInvestigation > tblStays.Ist_OPDatum) AND (tblStays.ParticID ='{2}') " +
                                        "AND ( " +
                                                "(tblFollowUp.ID = (SELECT TOP (1) f.ID FROM tblFollowUp AS f WHERE (f.FK_StayID = tblStays.ID) AND (f.fldFUP_Ereignis = {3} OR f.fldFUP_Ereignis = 3) ORDER BY fldFUP_DateInvestigation)) " +
                                                    "OR (tblFollowUp.ID = (SELECT TOP (1) ID FROM tblFollowUp AS f WHERE (FK_StayID = tblStays.ID) AND (fldFUP_Ereignis = 0) AND ((SELECT Count(*) FROM tblFollowUp AS f1 WHERE (f1.FK_StayID = tblStays.ID) AND ((f1.fldFUP_Ereignis <> -1) AND (f1.fldFUP_Ereignis <> 0))) = 0) ORDER BY fldFUP_DateInvestigation DESC)) " +
                                                ") " +
                                "ORDER BY tblStays.Ist_OPDatum", sDat, eDat, IDParticipant, Ereignis);

            DataTable dt = new DataTable();
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            da.SelectCommand = cmd;
            qs2.core.dbBase.setConnection(ref da);
            da.Fill(rs);

            return rs;
        }


    }
}
