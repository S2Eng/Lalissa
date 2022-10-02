using System;
using System.Collections.Generic;
using System.Text;
using PMDS.GUI.BaseControls;
using PMDS.Data.Global;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Print.CR;
using PMDS.Global.db.Global;
using PMDS.Global.db.Patient;

namespace PMDS.DynReportsForms
{
    public class MedikamentenBlattDataSource : IDynReportsDataSource
    {

        private static dsRepMedikamentenBlatt ds = new dsRepMedikamentenBlatt();
        private static dsRepMedikamentenBlatt.MedikamentenblattTableRow dsmblattrow;
        private static Medikament _med = new Medikament();

        public static string colHerrichtenSortierung = "HerrichtenSortierung";



        public MedikamentenBlattDataSource()
        {
        }



        public static int orderByHerrichten(int Herrichten)
        {
            try
            {
                if (Herrichten == (int)medHerrichten.langfristig)
                {
                    return 1;
                }
                else if (Herrichten == (int)medHerrichten.kurzfristig)
                {
                    return 2;
                }
                else if (Herrichten == (int)medHerrichten.nein)
                {
                    return 3;
                }
                else if (Herrichten == (int)medHerrichten.aerztlich)
                {
                    return 4;
                }
                else if (Herrichten == (int)medHerrichten.suchtgift)
                {
                    return 5;
                }
                else if (Herrichten == (int)medHerrichten.beiBedarf)
                {
                    return 6;
                }
                else
                {
                    return 100;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("orderByHerrichten: " + ex.ToString());
            }
        }
        public System.Data.DataSet GetDataSource(List<BerichtParameter> berichtpara)
        {
            return FilldsMBlatt(null, Guid.Empty, false);
        }

        public static dsRepMedikamentenBlatt FilldsMBlatt(dsRezeptEintrag.RezeptEintragDataTable dt, Guid IDAufenthalt, bool AbgesetzteMedNo) //für aufruf über stammblatt und medikamentenblatt
        {
            DateTime dNow = DateTime.Now;
            Guid IDAufenthaltbyCurrentPatient = Aufenthalt.LastByPatient(ENV.CurrentIDPatient);

            ds.MedikamentenblattTable.Rows.Clear();
            if (dt == null)
            {
                Rezept rez = new Rezept();
                dt = rez.Read(IDAufenthaltbyCurrentPatient);
            }

            if (!ds.MedikamentenblattTable.Columns.Contains(MedikamentenBlattDataSource.colHerrichtenSortierung.Trim()))
            {
                ds.MedikamentenblattTable.Columns.Add(MedikamentenBlattDataSource.colHerrichtenSortierung.Trim(), typeof(int));
            }

            foreach (dsRezeptEintrag.RezeptEintragRow r in dt.Rows)
            {
                dsmblattrow = ds.MedikamentenblattTable.NewMedikamentenblattTableRow();
                dsmblattrow.IDRezeptEintrag = r.ID;
                dsmblattrow.Dosierung = PMDS.BusinessLogic.Tools.ToStringFromRezepteintragRow(r);
                dsmblattrow.AbzugebenVon = r.AbzugebenVon;
                dsmblattrow.AbzugebenBis = r.AbzugebenBis;
                dsmblattrow.Applikationsform = r.Applikationsform.Trim();
                dsmblattrow.IDAufenthalt = (IDAufenthalt == Guid.Empty ? IDAufenthaltbyCurrentPatient : IDAufenthalt);
                dsmblattrow.IDKlient = (IDAufenthalt == Guid.Empty ? ENV.CurrentIDPatient : new Aufenthalt(IDAufenthalt).IDPatient);
                dsmblattrow.BedarfsMedikationJN = r.BedarfsMedikationJN;
                dsmblattrow.Einheit = r.Einheit.Trim();
                dsmblattrow.Bemerkung = r.Bemerkung.Trim();
                dsmblattrow.MedikamentBezeichnung = ((PMDS.Global.db.Patient.dsMedikament.MedikamentRow)(_med.ReadMedikament(r.IDMedikament).Rows[0])).Bezeichnung.Trim();
                if (!r.IsIDArztAbgesetztNull())
                {
                    dsmblattrow.IDArztAbgesetzt = r.IDArztAbgesetzt; 
                }

                dsmblattrow[PMDS.DynReportsForms.MedikamentenBlattDataSource.colHerrichtenSortierung.Trim()] = PMDS.DynReportsForms.MedikamentenBlattDataSource.orderByHerrichten(r.Herrichten);

                if (AbgesetzteMedNo)
                {
                    if (r.AbzugebenBis < dNow)
                    {
                        // do not show in report
                    }
                    else
                    {
                        ds.MedikamentenblattTable.Rows.Add(dsmblattrow);
                    }
                }
                else
                {
                    ds.MedikamentenblattTable.Rows.Add(dsmblattrow);
                }
            }

            ds = (dsRepMedikamentenBlatt)dsaddheaderinfo(IDAufenthalt == Guid.Empty ? IDAufenthaltbyCurrentPatient : IDAufenthalt, ds);
//#if DEBUG
//            ds.WriteXml(System.IO.Path.Combine(Settings.ReportPath, "dsRepMedikamentenBlatt.xml"), System.Data.XmlWriteMode.WriteSchema);
//#endif

            return ds;
        }
        private static dsRepMedikamentenBlatt dsaddheaderinfo(Guid IDAufenthalt, dsRepMedikamentenBlatt ds)
        {
            Patient pat = new Patient(new Aufenthalt(IDAufenthalt).IDPatient);
            Aufenthalt auf = pat.Aufenthalt;            //<20120216>
    
            Klinik k = new Klinik(auf.IDKlinik);

            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            dsKlinik.KlinikRow rKlinikActuell = DBKlinik1.loadKlinik(PMDS.Global.ENV.IDKlinik, true);

            PMDS.DB.DBAdresse DBAdresse1 = new PMDS.DB.DBAdresse();
            dsAdresse.AdresseRow rAdresse = DBAdresse1.loadAdresseKlinik(rKlinikActuell.IDAdresse, true);

            Abteilung a = new Abteilung();

            ds.Patient.Rows.Clear();
            ds.Klinik.Rows.Clear();
            //os 130917 pat.KrankenKasse
            ds.Patient.Rows.Add(pat.Vorname, pat.Nachname, pat.Geburtsdatum, pat.ID, auf.ID, a.GetAbteilungstext(auf.IDAbteilung), pat.KrankenKasse, pat.VersicherungsNr, pat.RezeptGebuehrbefreiungJN);
            
            ds.Klinik.Rows.Add(k.Bezeichnung, rAdresse.Plz + " " + rAdresse.Ort, rAdresse.Strasse);

            return ds;
        }


    }


    //für Gruppierung nach Hausarzt
    public class MedikamentenBlattDataSourceHausarzt : IDynReportsDataSource
    {
        private static dsRepMedikamentenBlatt ds = new dsRepMedikamentenBlatt();
        private static dsRepMedikamentenBlatt.MedikamentenblattTableRow dsmblattrow;
        private static Medikament _med = new Medikament();

        public MedikamentenBlattDataSourceHausarzt()
        {
        }

        public System.Data.DataSet GetDataSource(List<PMDS.Print.CR.BerichtParameter> berichtpara)
        {
            return FilldsMBlatt(null, Guid.Empty);
        }

        public static dsRepMedikamentenBlatt FilldsMBlatt(dsRezeptEintrag.RezeptEintragDataTable dt, Guid IDAufenthalt) //für aufruf über stammblatt und medikamentenblatt
        {
            Aerzte ArztListe = new Aerzte();
            dsPatientAerzte.PatientAerzteDataTable PatientArztTable = ArztListe.ALLAKTIVEPATIENTHAUSAERZTE.PatientAerzte;

            ds.MedikamentenblattTable.Rows.Clear();
            ds.Patient.Rows.Clear();
            ds.PatientHausArzt.Rows.Clear();
            Guid IDAufenthaltbyCurrentPatient;
            foreach (dsPatientAerzte.PatientAerzteRow PatArztRow in PatientArztTable.Rows)
            {
                IDAufenthaltbyCurrentPatient = Aufenthalt.LastByPatient(PatArztRow.IDPatient);

                Rezept rez = new Rezept();
                dt = rez.Read(IDAufenthaltbyCurrentPatient);

                foreach (dsRezeptEintrag.RezeptEintragRow r in dt.Rows)
                {
                    dsmblattrow = ds.MedikamentenblattTable.NewMedikamentenblattTableRow();
                    dsmblattrow.IDRezeptEintrag = r.ID;
                    dsmblattrow.Dosierung = PMDS.BusinessLogic.Tools.ToStringFromRezepteintragRow(r);
                    dsmblattrow.AbzugebenVon = r.AbzugebenVon;
                    dsmblattrow.AbzugebenBis = r.AbzugebenBis;
                    dsmblattrow.Applikationsform = r.Applikationsform;
                    dsmblattrow.IDAufenthalt = (IDAufenthaltbyCurrentPatient);
                    dsmblattrow.IDKlient = (PatArztRow.IDPatient);
                    dsmblattrow.BedarfsMedikationJN = r.BedarfsMedikationJN;
                    dsmblattrow.Einheit = r.Einheit;
                    dsmblattrow.Bemerkung = r.Bemerkung;
                    dsmblattrow.MedikamentBezeichnung = ((PMDS.Global.db.Patient.dsMedikament.MedikamentRow)(_med.ReadMedikament(r.IDMedikament).Rows[0])).Bezeichnung;

                    ds.MedikamentenblattTable.Rows.Add(dsmblattrow);
                }
                Patient pat = new Patient(new Aufenthalt(IDAufenthaltbyCurrentPatient).IDPatient);
                Aufenthalt auf = pat.Aufenthalt;
                ds.Patient.Rows.Add(pat.Vorname, pat.Nachname, pat.Geburtsdatum, pat.ID, auf.ID, new Abteilung().GetAbteilungstext(pat.Aufenthalt.IDAbteilung), pat.KrankenKasse, pat.VersicherungsNr, pat.RezeptGebuehrbefreiungJN);
                dsAerzte.AerzteRow ArztRow = Aerzte.GetArztDetails(PatArztRow.IDAerzte);
                ds.PatientHausArzt.Rows.Add(ArztRow.ID, PatArztRow.IDPatient, ArztRow.Titel, ArztRow.Vorname, ArztRow.Nachname);
            }
            return (dsRepMedikamentenBlatt)dsaddheaderinfo(ds);
        }
        private static dsRepMedikamentenBlatt dsaddheaderinfo(dsRepMedikamentenBlatt ds)
        {
            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            dsKlinik.KlinikRow rKlinikActuell = DBKlinik1.loadKlinik(PMDS.Global.ENV.IDKlinik, true);

            PMDS.DB.DBAdresse DBAdresse1 = new PMDS.DB.DBAdresse();
            dsAdresse.AdresseRow rAdresse = DBAdresse1.loadAdresseKlinik(rKlinikActuell.IDAdresse, true);

            ds.Klinik.Rows.Clear();
            ds.Klinik.Rows.Add(rKlinikActuell.Bezeichnung, rAdresse.Plz + " " + rAdresse.Ort, rAdresse.Strasse);

            return ds;
        }

    }
}
