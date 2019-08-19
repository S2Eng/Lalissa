using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using PMDS.Abrechnung.Global;
using PMDS.Calc.Admin.DB;
using PMDS.Global;
using PMDS.Data.Global;



namespace PMDS.BusinessLogic.Abrechnung
{


	public class PatientEinkommen
	{


		private DBPatientEinkommen _db = new DBPatientEinkommen();

		public PatientEinkommen()
		{
		}


        //public dsPatientEinkommen.PatientEinkommenDataTable Read(Guid IDKlinik)
        //{
        //    return _db.Read(IDKlinik);
        //}

        public dsPatientEinkommen.PatientEinkommenDataTable Readxy(Guid IDPatient, Guid IDKlinik)
        {
            return _db.Read(IDPatient, IDKlinik);
        }

        public dsPatientEinkommen.PatientEinkommenDataTable Readxyxy(Guid IDKostentraeger, List<Guid> lIDPatient, DateTime GueltigAb, Guid IDKlinik)
        {
            return _db.Read(IDKostentraeger, lIDPatient, GueltigAb, IDKlinik);
        }

        public dsPatientEinkommen.PatientEinkommenRow ReadByID(Guid IDPatientEinkommen)
        {
            return _db.ReadByID(IDPatientEinkommen);
        }

		public void Update(dsPatientEinkommen.PatientEinkommenDataTable dt)
		{
			_db.Update(dt);
		}
        public dsPatientEinkommen.PatientEinkommenRow New(dsPatientEinkommen.PatientEinkommenDataTable dt, Guid IDPatient, bool TransferleistungJN, Guid IDKlinik)
		{
            DateTime von = TransferleistungJN ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) : DateTime.Now.Date;
            dsPatientEinkommen.PatientEinkommenRow r = dt.AddPatientEinkommenRow(Guid.NewGuid(), IDPatient, "", 0, von, DateTime.Now.Date, TransferleistungJN, false, DateTime.Now, Guid.Empty, DateTime.Now, Guid.Empty, Guid.Empty, 0, false, System.Guid.Empty);
            r.IDKlinik = IDKlinik;
            r.SetGueltigBisNull();
            r.IDBenutzer = ENV.USERID;
            r.SetAbgerechnetBisNull();
            r.SetIDKostentraegerNull();
            r.SetIDBanklisteNull();
            r.SetZahlartNull();
			return r;
		}

        public Einkommen[] AllValid(Guid IDpatient, int jahr, int monat, Guid IDKlinik)
        {
            DateTime dt = new DateTime(jahr, monat, 1);
			// rtf: neue kontrolle, welche Einkommen gültig sind
			DateTime dtBis = new DateTime (jahr, monat, DateTime.DaysInMonth(jahr, monat));

            ArrayList al = new ArrayList();
            dsPatientEinkommen.PatientEinkommenDataTable datat = Readxy(IDpatient, IDKlinik);
            foreach (dsPatientEinkommen.PatientEinkommenRow r in datat)
            {
                if (r.IsGueltigBisNull())
                    r.GueltigBis = r.TransferleistungJN ? r.GueltigAb : abrech.GueltigBis;
                
                if (r.GueltigAb <= dtBis && r.GueltigBis >= dt)
                    al.Add(new Einkommen(r.ID, r.Bezeichnung, r.BetragVerwendbar, r.GueltigAb, r.GueltigBis, r.TransferleistungJN, r.SelbstzahlerJN, r.IsIDKostentraegerNull() ? Guid.Empty : r.IDKostentraeger));
            }

            return (Einkommen[]) al.ToArray(typeof(Einkommen));
        }

        public dsPatientEinkommen.PatientEinkommenDataTable ReadOnlyTransferKostentraeger(Guid IDPatient, Guid IDKlinik)
        {
            return _db.ReadOnlyTransferKostentraeger(IDPatient, IDKlinik);
        }

        public dsPatientEinkommen.PatientEinkommenDataTable ReadOnlyNotTransferEinkommen(Guid IDPatient, Guid IDKlinik)
        {
            return _db.ReadOnlyNotTransferEinkommen(IDPatient, IDKlinik);
        }

        public dsPatientEinkommen.PatientEinkommenDataTable ReadByKostentraeger(Guid IDKostentraeger, Guid IDKlinik)
        {
            return _db.ReadByKostentraeger(IDKostentraeger, IDKlinik);
        }

        public dsPatientEinkommen.PatientEinkommenDataTable ReadByKostentraeger(List<Guid> lIDKostentraeger, Guid IDKlinik)
        {
            return _db.ReadByKostentraeger(lIDKostentraeger, IDKlinik);
        }
}

    public class Einkommen
    {
        public Einkommen(Guid IDPatientEinkommen, string sBezeichnung, double dblBetrag, DateTime dtAb, DateTime dtBis, bool transferLeistungJN, bool selbstzahlerJN, Guid idKostentraeger)
        {
            ID = IDPatientEinkommen;
            Bezeichnung = sBezeichnung;
            Betrag = dblBetrag;
			GueltigAb = dtAb;
			GueltigBis = dtBis;
            TransferLeistungJN = transferLeistungJN;
            SelbstzahlerJN = selbstzahlerJN;
            IDKostentraeger = idKostentraeger;
        }
        public Guid ID;
        public string Bezeichnung = "";
        public double Betrag = 0;
		public DateTime GueltigAb, GueltigBis;
        public bool TransferLeistungJN;
        public bool SelbstzahlerJN;
        public Guid IDKostentraeger;
    }
}
