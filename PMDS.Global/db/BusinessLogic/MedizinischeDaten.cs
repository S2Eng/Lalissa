using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB.Global;
using PMDS.Data.Global;
using System.Net;
using PMDS.Global.db.Global;



namespace PMDS.BusinessLogic
{


    public class MedizinischeDaten
    {
        private DBMedizinischeDaten _db = new DBMedizinischeDaten();
     

        public dsMedizinischeDaten.MedizinischeDatenDataTable GetOpenFromTyp(Guid IDPatient, int Medizinischertyp)
        {
            return _db.GetOpenFromTyp(IDPatient, Medizinischertyp);
        }


        /// Schließt den offenen zum Medizinischen Typ zugehörigen Datensatz
        public void CloseOpenType(Guid IDPatient, int Medizinischertyp, string sEndegrund, string sBeschreibung, DateTime dtEnde)
        {
            _db.CloseOpenType(IDPatient, Medizinischertyp, sEndegrund, sBeschreibung, dtEnde);
        }

        /// Fügt dem Datatable einen neuen Datensatz hinzu und speichert ihn in die DB
        public void AddNewOpen(dsMedizinischeDaten.MedizinischeDatenDataTable dt, Guid IDPatient, Guid IDBenutzergeaendert, int Medizinischertyp, string sBemerkung, string sBeschreibung, DateTime dtVon)
        {
            dsMedizinischeDaten.MedizinischeDatenRow r = dt.NewMedizinischeDatenRow();
            r.ID                    = Guid.NewGuid();
            r.IDPatient             = IDPatient;
            r.IDBenutzergeaendert   = IDBenutzergeaendert;
            r.Von                   = dtVon;
            r.Bemerkung             = sBemerkung;
            r.MedizinischerTyp      = Medizinischertyp;
            r.Beschreibung          = sBeschreibung;
            r.Groesse = "";
            r.SetIDBefundNull();
            r.Verordnungen = "";
            r.lstRezepteinträge = "";
        
            dt.AddMedizinischeDatenRow(r);
            _db.Update(dt);
        }

    }
}
