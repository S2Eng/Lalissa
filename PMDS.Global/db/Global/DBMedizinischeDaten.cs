using PMDS.Global.db.Global;
using RBU;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;

namespace PMDS.DB.Global
{
    //----------------------------------------------------------------------------
    /// <summary>
    /// Zugriff und speicherung auf die MedizinischenDaten
    /// </summary>
    //----------------------------------------------------------------------------
    public partial class DBMedizinischeDaten : Component
    {
        public DBMedizinischeDaten()
        {
            InitializeComponent();
        }

        public DBMedizinischeDaten(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert einen Datatable mit einer Row wenn ein offener existiert
        /// oder einen Table ohne Row wenn keiner existiert
        /// </summary>
        //----------------------------------------------------------------------------
        public dsMedizinischeDaten.MedizinischeDatenDataTable GetOpenFromTyp(Guid IDPatient, int Medizinischertyp)
        {
            dsMedizinischeDaten.MedizinischeDatenDataTable dt = new dsMedizinischeDaten.MedizinischeDatenDataTable();
            daAllOpen.SelectCommand.Parameters[0].Value = IDPatient;
            daAllOpen.SelectCommand.Parameters[1].Value = Medizinischertyp;
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            daAllOpen.SelectCommand.Connection = RBU.DataBase.CONNECTION;
            daAllOpen.Fill(dt);
            return dt;
        }

        public dsMedizinischeDaten.MedizinischeDatenDataTable GetOpenFromTypRam(ref string sWherePatienten)
        {
            dsMedizinischeDaten.MedizinischeDatenDataTable dt = new dsMedizinischeDaten.MedizinischeDatenDataTable();
            //daAllOpenRam.SelectCommand.Connection = RBU.DataBase.CONNECTION;
            //daAllOpenRam.SelectCommand.CommandText += "where " + sWherePatienten; 
            //daAllOpenRam.Fill(dt);
            //return dt;

            OleDbDataAdapter daTmp = new OleDbDataAdapter();
            OleDbCommand selCmdTmp = new OleDbCommand();
            selCmdTmp.CommandText +=  daAllOpenRam.SelectCommand.CommandText +  "where " + sWherePatienten; 
            daTmp.SelectCommand = selCmdTmp;
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            selCmdTmp.Connection = RBU.DataBase.CONNECTION;
            daTmp.Fill(dt);
            return dt;
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Schließt den offenen zum Medizinischen Typ zugehörigen Datensatz
        /// </summary>
        //----------------------------------------------------------------------------
        public void CloseOpenType(Guid IDPatient, int Medizinischertyp, string sEndegrund, string sBeschreibung, DateTime dtEnde)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Update MedizinischeDaten set bis = ?, Beendigungsgrund = ?, Beschreibung = ? where IDPatient = ? and Medizinischertyp = ? and not von is null and bis is null";

            OleDbParameter bis = new OleDbParameter { ParameterName = "bis", OleDbType = OleDbType.Date, Value = dtEnde };
            cmd.Parameters.Add(bis);

            cmd.Parameters.AddWithValue("Beendigungsgrund", sEndegrund);
            cmd.Parameters.AddWithValue("Beschreibung", sBeschreibung);
            cmd.Parameters.AddWithValue("IDPatient", IDPatient);
            cmd.Parameters.AddWithValue("Medizinischertyp", Medizinischertyp);
            DataBase.EcecuteNonQuery(cmd);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Speichert die Änderungen in der Datenbank
        /// </summary>
        //----------------------------------------------------------------------------
        public void Update(dsMedizinischeDaten.MedizinischeDatenDataTable dt)
        {
            DataBase.Update(daMedizinischeDaten, dt);
        }
        
    }
}
