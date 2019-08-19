using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Data.Global;
using PMDS.DB.Global;
using PMDS.Global.db.Global;



namespace PMDS.BusinessLogic
{

    public class Standardzeiten
    {
        private static string[]     _aStandardzeiten;
        private static DateTime[]   _aStandardzeitenTimes;
        DBStandardzeiten _db;



        public Standardzeiten()
        {
            _db = new DBStandardzeiten();
        }



        public dsStandardZeiten STANDARDZEITEN
        {
            get { return _db.STANDARDZEITEN; }
        }
        public void Read()
        {
            _db.Read();
        }

        public void Write()
        {
            _db.Write();
        }

        public static void RefreshStandardzeiten()
        {
            _aStandardzeiten = null;
            _aStandardzeitenTimes = null;
        }

        // Liefert die Standardzeiten Texte als String []
        public static string[] StandardzeitenStrings
        {
            get
            {
                //InitStandardzeiten();
                return _aStandardzeiten;
            }
        }

        // Liefert die Standardzeiten Zeitpunkte
        public static DateTime[] StandardzeitenZeitpunkte
        {
            get
            {
                return _aStandardzeitenTimes;
            }
        }

        // Standardzeiten initialisieren
        public static void InitStandardzeiten()
        {
            if (_aStandardzeiten == null)
            {
                List<string>    al  = new List<string>();
                List<DateTime>  alt = new List<DateTime>();
                DBStandardzeiten db = new DBStandardzeiten();
                db.Read();
                foreach (dsStandardZeiten.StandardzeitenRow r in db.STANDARDZEITEN.Standardzeiten)
                {
                    al.Add(r.Bezeichnung);
                    alt.Add(r.Zeitpunkt);
                }
                _aStandardzeiten = al.ToArray();
                _aStandardzeitenTimes = alt.ToArray();
            }
        }
    }
}
