using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PMDS.DB.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global.ds_abrechnung;


namespace PMDS.BusinessLogic
{


    public class MedizinischeDatenLayout
    {

        private DBMedizinischeDatenLayout _db;
        private string[] _columns = {"Beschreibung", "Bemerkung", "Beendigungsgrund", "Therapie", "Typ" };      // Die konfigurierbaren Spalten
        


        public MedizinischeDatenLayout()
        {
            _db = new DBMedizinischeDatenLayout();
        }

        public PMDS.Global.db.Global.dsMedizinischeDatenLayout ALL
        {
            get { return _db.ALL; }
        }


        /// Liefert ein String[] (in der richtigen Reihenfolge) der anzuzeigenden 
        /// Spalten des Layouts
        /// Im Layout kann die Reihenfolge füe 5 Spalten definiert werden. Null signalisier
        /// das die Saplte bei dem jeweiligen Typ nicht benötigt wird.
        /// In der DatenTabelle heißen die Spalten genauso wie in der Layout Tabelle
        /// 
        /// Wenn null geliefert wird, dann bedeutet das dass der Typ nicht konfiguriert ist
        /// es werden dann alle verfügbaren Spalten geliefert
        public string[] GetColumnsToDisplay(int medtyp)
        {
            List<string> al = new List<string>();
            PMDS.Global.db.Global.dsMedizinischeDatenLayout.MedizinischeDatenLayoutRow r = _db.ReadByType(medtyp);
            if (r == null)                              // bei nicht konfiguration ==> alle Spalten als Default
            {
                foreach (string s in _columns)
                    al.Add(s);
                return al.ToArray();
            }

            for (int i = 1; i < 6; i++)                 // alle 5 Spalten abarbeiten und die richtige Reihenfolge liefern
            {
                string s = LookFor(r, i);
                if (s.Length == 0)
                    break;
                al.Add(s);
            }


            return al.ToArray();
        }


        /// Prüft ob i in einer spalte vorkommt
        private string LookFor(DataRow r, int i)
        {
            foreach (string s in _columns)
            {
                if (r.IsNull(s))
                    continue;

                int i2 = (int)r[s];
                if (i2 >= 1000)
                {
                    i2 = i2 - 1000;
                }

                if (i2 == i)
                    return s;
            }
            return "";
        }

        public void Read()
        {
            _db.Read();
        }

        public void Write()
        {
            _db.Write();
        }
    }
}
