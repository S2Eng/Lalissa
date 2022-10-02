//----------------------------------------------------------------------------
/// <summary>
///	25.9.2008 RBU: DBLayer Wunde    
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using PMDS.Data.Global;
using RBU;
using System.Data.OleDb;
using PMDS.Global;
using System.Data;

namespace PMDS.DB.Global
{
    public partial class DBWunde : Component
    {
        public DBWunde()
        {
            InitializeComponent();
        }

        public DBWunde(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert alle Thumbs zu einer WundeKopf
        /// </summary>
        //----------------------------------------------------------------------------
        public dsWunde GetAllThumbs(Guid IDWundeKopf)
        {
            dsWunde ds = new dsWunde();
            daWundePosAllThumbs.SelectCommand.Parameters[0].Value = IDWundeKopf;
            DataBase.Fill(daWundePosAllThumbs, ds.WundePosBilder);
            return ds;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Lesen
        /// </summary>
        //----------------------------------------------------------------------------
        public dsWunde ReadKopfPos(Guid IDAufenthaltPdx)
        {
            dsWunde ds = new dsWunde();
            daWundeKopf.SelectCommand.Parameters[0].Value = IDAufenthaltPdx;                // Kopfdaten lesen zur AUdenthaltPDx
            DataBase.Fill(daWundeKopf, ds);
            if (ds.WundeKopf.Count == 1)
            {
                daWundePos.SelectCommand.Parameters[0].Value = ds.WundeKopf[0].ID;          // Die zum Kopf gehörigen Pos Daten lesen
                DataBase.Fill(daWundePos, ds.WundePos);
                
                //DataTable dt = new DataTable();
                daWundeTherapie.SelectCommand.Parameters[0].Value = ds.WundeKopf[0].ID;     // Therapieinfos laden
                DataBase.Fill(daWundeTherapie, ds.WundeTherapie);
            }
            else if (ds.WundeKopf.Rows.Count > 1)
            {
                string sExceptIDs = "Error Wunde.ReadKopfPos - Rows WundeKopf>1";
                foreach (dsWunde.WundeKopfRow r in ds.WundeKopf)
                {
                    sExceptIDs += "r.ID=" + r.ID.ToString() + "     r.IDAufenthaltPDx=" + r.IDAufenthaltPDx.ToString() + "\r\n";
                }
                System.Windows.Forms.MessageBox.Show("Es ist ein Fehler aufgetreten. Bitte rufen Sie umgehend S2-Engineering GmbH unter 07252/22080 an!" + "\r\n" + sExceptIDs);
                throw new Exception("DBWunde.ReadKopfPos: " + sExceptIDs + "" + "\r\n" + "");
            }
            else if (ds.WundeKopf.Count == 0)
            {
                dsWunde.WundeKopfRow r = ds.WundeKopf.NewWundeKopfRow();
                r.ID = Guid.NewGuid();
                r.IDAufenthaltPDx = IDAufenthaltPdx;
                r.Wundart = "";
                r.Dekuskala = "";
                r.Dekuwert = 0;
                r.ClickedValueY = -1;
                r.ClickedValueX = -1;
                r.WundeEntstanden = "";
                ds.WundeKopf.AddWundeKopfRow(r);
            }
            return ds;
        }

        public dsWunde readWundeTherapieByID(Guid ID)
        {
            dsWunde ds = new dsWunde();
            this.daWundeTherapieByID.SelectCommand.Parameters[0].Value = ID;    
            DataBase.Fill(this.daWundeTherapieByID, ds.WundeTherapie);
            return ds;
        }

        public dsWunde readWundePosByID(Guid ID)
        {
            dsWunde ds = new dsWunde();
            this.daWundePosByID.SelectCommand.Parameters[0].Value = ID;
            DataBase.Fill(this.daWundePosByID, ds.WundePos);
            return ds;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Bilder lesen
        /// </summary>
        //----------------------------------------------------------------------------
        public void FillBilder(Guid IDWundePos, dsWunde ds)
        {
            daWundePosBilder.SelectCommand.Parameters[0].Value = IDWundePos;                
            DataBase.Fill(daWundePosBilder, ds);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Festschreiben des BilderDatatables(nicht transaktionell (muss vom caller verarbeitet werden)
        /// </summary>
        //----------------------------------------------------------------------------
        public void Write(dsWunde.WundePosBilderDataTable dt)
        {
            UpdateChangesFields(dt);             // Änderungshistorie auch für Bilder
            DataBase.Update(daWundePosBilder, dt);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Festschreiben (nicht transaktionell (muss vom caller verarbeitet werden)
        /// </summary>
        //----------------------------------------------------------------------------
        public void Write(dsWunde ds)
        {
            /*
            // Constraints disablen
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "ALTER TABLE WundeKopf NOCHECK CONSTRAINT ALL ";
            DataBase.EcecuteNonQuery(cmd);
            cmd.CommandText = "ALTER TABLE WundePos NOCHECK CONSTRAINT ALL ";
            DataBase.EcecuteNonQuery(cmd);
            cmd.CommandText = "ALTER TABLE WundePosBilder NOCHECK CONSTRAINT ALL ";
            DataBase.EcecuteNonQuery(cmd);
            cmd.CommandText = "ALTER TABLE WundeTherapie NOCHECK CONSTRAINT ALL ";
            DataBase.EcecuteNonQuery(cmd);
            */

            // Benutzer etc. speichern
            foreach (dsWunde.WundeKopfRow r in ds.WundeKopf)
            {
                if (r.RowState == System.Data.DataRowState.Added)
                {
                    r.IDBenutzer_Erstellt   = ENV.USERID;
                    r.DatumErstellt = DateTime.Now;
                }

                r.IDBenutzer_Geaendert  = ENV.USERID;
                r.DatumGeaendert        = DateTime.Now;
            }

            foreach (dsWunde.WundePosRow r in ds.WundePos)
            {
                //Wird jetzt in der Neuanlage befüllt
                //if (r.RowState == System.Data.DataRowState.Added)
                //{
                //    r.IDBenutzer_Erstellt   = Settings.USERID;
                //    r.DatumErstellt         = DateTime.Now;
                //}
                if (r.RowState == System.Data.DataRowState.Modified)
                {
                    r.IDBenutzer_Geaendert  = ENV.USERID;
                    r.DatumGeaendert        = DateTime.Now;
                }
            }

            foreach (dsWunde.WundeTherapieRow r in ds.WundeTherapie)
            {
                //Wird jetzt bereits bei der Neuanlage befüllt.
                //if (r.RowState == System.Data.DataRowState.Added)
                //{
                //    r.IDBenutzer_Erstellt   = Settings.USERID;
                //    r.DatumErstellt         = DateTime.Now;
                //}

                if (r.RowState == System.Data.DataRowState.Modified)
                {
                    r.IDBenutzer_Geaendert = ENV.USERID;
                    r.DatumGeaendert = DateTime.Now;
                }              
            }

            UpdateChangesFields(ds.WundePosBilder);             // Änderungshistorie auch für Bilder

            // Daten festschreiben
            if (ds.WundeKopf.Rows.Count == 0)
            {
                throw new Exception("DBWunde.Write: " + "ds.WundeKopf.Rows.Count=0" + "!");
            }
            if (ds.WundeKopf.Rows.Count > 1)
            {
                string sExceptIDs = "Error Wunde.Save - Rows WundeKopf>1";
                foreach (dsWunde.WundeKopfRow r in ds.WundeKopf)
                {
                    sExceptIDs += "r.ID=" + r.ID.ToString() + "     r.IDAufenthaltPDx=" + r.IDAufenthaltPDx.ToString() + "\r\n";
                }
                System.Windows.Forms.MessageBox.Show("Es ist ein Fehler aufgetreten. Bitte rufen Sie umgehend S2-Engineering GmbH unter 07252/22080 an!" + "\r\n" + sExceptIDs);
                throw new Exception("DBWunde.Write: " + sExceptIDs + "" + "\r\n" + "");
            }
            try
            {
                DataBase.Update(daWundeKopf, ds);
            }
            catch (Exception ex5)
            {
                dsWunde.WundeKopfRow r = (dsWunde.WundeKopfRow)ds.WundeKopf.Rows[0];
                string sExceptID2s = "rWundeKopf.ID=" + r.ID.ToString() + "         rWundeKopf.IDAufenthaltPDx=" + r.IDAufenthaltPDx.ToString() + "\r\n";
                throw new Exception("DBWunde.WriteError56: " + sExceptID2s + "" + "\r\n" + "");
            }
         
            DataBase.Update(daWundePos, ds);
            DataBase.Update(daWundePosBilder, ds);
            DataBase.Update(daWundeTherapie, ds);

            /*
            // Constraints enablen
            cmd.CommandText = "ALTER TABLE WundeKopf CHECK CONSTRAINT ALL ";
            DataBase.EcecuteNonQuery(cmd);
            cmd.CommandText = "ALTER TABLE WundePos CHECK CONSTRAINT ALL ";
            DataBase.EcecuteNonQuery(cmd);
            cmd.CommandText = "ALTER TABLE WundePosBilder CHECK CONSTRAINT ALL ";
            DataBase.EcecuteNonQuery(cmd);
            cmd.CommandText = "ALTER TABLE WundeTherapie CHECK CONSTRAINT ALL ";
            DataBase.EcecuteNonQuery(cmd);
            */


        }

        private void UpdateChangesFields(dsWunde.WundePosBilderDataTable dt)
        {

            foreach (dsWunde.WundePosBilderRow r in dt)
            {
                if (r.RowState == DataRowState.Deleted)
                    continue;

                if (r.RowState == DataRowState.Added)
                {
                    r.IDBenutzer_Erstellt = ENV.USERID;
                    r.DatumErstellt = DateTime.Now;
                }

                if (r.RowState == DataRowState.Modified)
                {
                    r.IDBenutzer_Geaendert = ENV.USERID;
                    r.DatumGeaendert = DateTime.Now;
                }               
            }
        }
    }
}
