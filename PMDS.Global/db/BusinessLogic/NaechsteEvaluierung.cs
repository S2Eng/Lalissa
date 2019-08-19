using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using RBU;

namespace PMDS.BusinessLogic
{
    /// <summary>
    /// Zugriffsklasse für die Letzte Evaluierungsfunktion im Modus gesamter Klient
    /// </summary>
    public class NaechsteEvaluierungKlient
    {
        private DateTime _Datum;
        private string  _Anmerkung = "";
        private Guid    _IDAufenthalt;
        
        public NaechsteEvaluierungKlient(Guid IDPatient)
        {
            _IDAufenthalt = Aufenthalt.LastByPatient(IDPatient);
            Aufenthalt a = new Aufenthalt(_IDAufenthalt);
            _Datum = a.NaechsteEvaluierung;
            _Anmerkung = a.NaechsteEvaluierungBemerkung;
        }

        public void Write(DateTime naechsteEvaluierung, string Bemerkung)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Update dbo.Aufenthalt set NaechsteEvaluierung = ?, NaechsteEvaluierungBemerkung = ? where ID = ?";
            cmd.Parameters.AddWithValue("NaechsteEvaluierung", naechsteEvaluierung);
            cmd.Parameters.AddWithValue("NaechsteEvaluierungBemerkung", Bemerkung);
            cmd.Parameters.AddWithValue("ID", _IDAufenthalt);
            DataBase.EcecuteNonQuery(cmd);
        }

        public DateTime Datum
        {
            get { return _Datum; }
        }


        public string Anmerkung
        {
            get { return _Anmerkung; }
        }

    }
}
