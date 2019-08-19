using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PMDS.Data.Global;
using PMDS.DB.Global;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{
    public class Zeitbereich
    {
        private DBZeitbereich _db = new DBZeitbereich();

        private static dsZeitbereich.ZeitbereichDataTable _dtCached;

        public Zeitbereich()
        {

        }
        

        //Liefert den Text eines Zeitbereiches >> Diese funktion nutzt einen internen Zeitbereich Cache
        public static string GetText(Guid IDZeitbereich)
        {
            if(_dtCached == null) 
            {
                DBZeitbereich db = new DBZeitbereich();
                _dtCached = db.Read();
            }

            dsZeitbereich.ZeitbereichRow r = _dtCached.FindByID(IDZeitbereich);
            if (r == null)
                return "";
            return r.Bezeichnung.Trim();
        }

        public dsZeitbereich.ZeitbereichDataTable Read()
        {
            return _db.Read();
        }

        public void Write(dsZeitbereich.ZeitbereichDataTable dt)
        {
            _db.Write(dt);
        }
    }

    public class ZeitbereichSerien
    {
        private DBZeitbereichSerien _db = new DBZeitbereichSerien();

        public ZeitbereichSerien()
        {
        }

        public dsZeitbereichSerien.ZeitbereichSerienDataTable Read()
        {
            return _db.Read();
        }

        public void Write(dsZeitbereichSerien.ZeitbereichSerienDataTable dt)
        {
            _db.Write(dt);
        }

        public Guid[] GetPoints(dsZeitbereichSerien.ZeitbereichSerienDataTable dt, Guid IDZeitbereichSerie)
        {
            List<Guid> list = new List<Guid>();
            dsZeitbereichSerien.ZeitbereichSerienRow r = dt.FindByID(IDZeitbereichSerie);

            if (r != null)
            {
                foreach (DataColumn c in dt.Columns)
                    if (c.ColumnName.StartsWith("IDZeitbereich"))
                        if (!r.IsNull(c))
                            list.Add((Guid)r[c.ColumnName]);
            }

            return list.ToArray();
        }
    }
}
