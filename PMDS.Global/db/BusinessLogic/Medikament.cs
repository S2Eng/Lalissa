using System;
using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Patient;



namespace PMDS.BusinessLogic
{


	public class Medikament
	{

		private DBMedikament		_db = new DBMedikament();
		public Medikament()
		{

		}




		/// Ermittelt sämtliche Datensätze welchen den übergebenen Kriterien entsprechen
		/// Leere Strings werden nicht ausgewertet
        public PMDS.Global.db.Patient.dsMedikament.MedikamentDataTable ReadMedikament(string LikeforBezeichnung, string LikeforLangText, 
                                        string LikeForEinheit, string LikeForGruppe, bool bFulltext, bool bUseAndInsteadOr,
                                        int Aktuell) 
		{
            return _db.ReadMedikament(LikeforBezeichnung, LikeforLangText, LikeForEinheit, LikeForGruppe, bFulltext, bUseAndInsteadOr, Aktuell);
		}

        public void Write(PMDS.Global.db.Patient.dsMedikament.MedikamentDataTable dt) 
		{
			_db.Write(dt);
		}

        public PMDS.Global.db.Patient.dsMedikament.MedikamentDataTable AllMedikamenteBig(int Aktuell, bool ReadAll) 
		{
            return _db.AllMedikamenteBig(Aktuell, ReadAll);
		}
        
		/// Ermittelt den Datensatz zur ID und liefert einen Datatable zurück
		/// der ist leer wenn der Datensatz nicht gefunden wurde
        public PMDS.Global.db.Patient.dsMedikament.MedikamentDataTable ReadMedikament(Guid IDMedikament) 
		{
            return _db.ReadMedikament(IDMedikament);
		}

		/// Liefert einen Datatable mit einem neuen Medikamenten Eintrag
        public dsMedikament.MedikamentRow New(dsMedikament.MedikamentDataTable ds) 
		{
            return _db.New(ds);
		}

	}
}
