using System;
using PMDS.Abrechnung.Global;
using PMDS.Calc.Admin.DB;



namespace PMDS.BusinessLogic.Abrechnung
{


	public class Pflegegeldstufe
	{

        private DBPflegegeldstufe _db = new DBPflegegeldstufe();



		public Pflegegeldstufe()
		{
		}

        public dsPflegegeldstufe Read()
        {
            return _db.Read(); ;
        }

        public dsPflegegeldstufe ReadByID(Guid IDPflegegeldstufe)
        {
            return _db.ReadByID(IDPflegegeldstufe);
        }

        public void Update(dsPflegegeldstufe ds, bool bDeleteOnly)
        {
            _db.Update(ds, bDeleteOnly);
        }

        //Neu nach 02.01.2008 MDA
        public void Update(dsPflegegeldstufe ds)
        {
            //Alle automatisch(durch löschen eine Pflegegeldstufe) gelöschte Rows in dsPflegegeldstufe.PflegegeldstufeGueltig entfernen
            //Sie werden mit Cascade gelöscht.
            dsPflegegeldstufe.PflegegeldstufeRow[] rows = (dsPflegegeldstufe.PflegegeldstufeRow[])ds.Pflegegeldstufe.Select("", "", System.Data.DataViewRowState.Deleted);
            dsPflegegeldstufe.PflegegeldstufeGueltigRow[] gRows;
            foreach (dsPflegegeldstufe.PflegegeldstufeRow r in rows)
            {
                r.RejectChanges();
                gRows = (dsPflegegeldstufe.PflegegeldstufeGueltigRow[])ds.PflegegeldstufeGueltig.Select("IDPflegegeldstufe = '" + r.ID.ToString() + "'", "", System.Data.DataViewRowState.Deleted);

                foreach (dsPflegegeldstufe.PflegegeldstufeGueltigRow rr in gRows)
                    ds.PflegegeldstufeGueltig.RemovePflegegeldstufeGueltigRow(rr);
                r.Delete();
            }

            _db.Update(ds, false);
        }

        public dsPflegegeldstufe.PflegegeldstufeRow New(dsPflegegeldstufe ds)
        {
            return ds.Pflegegeldstufe.AddPflegegeldstufeRow(Guid.NewGuid(), ds.Pflegegeldstufe.Count + 1, 30, "");
        }

        public dsPflegegeldstufe.PflegegeldstufeGueltigRow NewPflegegeldstufeGueltig(dsPflegegeldstufe ds, Guid IDPflegegeldstufe,
                                                                                     DateTime GueltigAb, double Betrag)
        {
            dsPflegegeldstufe.PflegegeldstufeRow r = ds.Pflegegeldstufe.FindByID(IDPflegegeldstufe);
            return ds.PflegegeldstufeGueltig.AddPflegegeldstufeGueltigRow(Guid.NewGuid(), r, GueltigAb, Betrag);
        }
	}
}
