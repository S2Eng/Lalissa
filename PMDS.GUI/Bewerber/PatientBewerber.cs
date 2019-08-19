using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.DB.Global;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.GUI.BaseControls;
using PMDS.GUI.Klient;
using PMDS.Global.db.Global;



namespace PMDS.BusinessLogic
{
    public class PatientBewerber : QS2.Desktop.ControlManagment.baseForm 
    {
        private   DBPatientbewerber _db;



        public PatientBewerber()
        {
            _db = new DBPatientbewerber();
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle Bewerber zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        public dsPatientBewerber ListBewerber
        {
            get { return _db.PatientBewerber; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle Klienten, die kein Bewerber sind, zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        public dsPatientBereich ListKlienten
        {
            get { return _db.ListKlienten; }
        }

        public void Read()
        {
            _db.Read();
        }
        public void Write()
        {
            _db.Write();
        }

        //Neu nach 05.07.2007 MDA
        public dsPatientBewerber.PatientRow ReadByID(Guid IDPatient)
        {
            return _db.ReadByID(IDPatient);
        }

        public void ReadByFilter2(string patient, DateTime bewerberVon, DateTime bewerberBis, DateTime einzzugswuschVon,
                                          DateTime einzzugswuschBis, string prioritaet, string pflegeart, Guid IDAbteilung,
                                          string Konfision, string Sexus, Guid IDBereich, Guid IDKlinik)
        {
            _db.ReadByFilter2(patient, bewerberVon, bewerberBis, einzzugswuschVon, einzzugswuschBis, prioritaet, pflegeart, IDAbteilung, 
                                Konfision, Sexus, IDBereich, IDKlinik);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle Klienten, die kein Bewerber sind, aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public void KlientByFilter(string patient)
        {
            _db.KlientByFilter(patient);
        }

        //Neu nach 05.07.2007 MDA
        public void InitBewerbungsdaten(dsPatientBewerber.PatientRow row)
        {
            if (row == null)
                return;
            row.BewerbungaktivJN = false;
            row.SetBewerbungDatumNull();
            row.Prioritaet = "";
            row.PflegeArt = "";
            row.SetEinzugswunschDatumNull();
            row.SetAuszugswunschDatumNull();
            row.BewerbungsGrund = "";
            row.Zimmerwunsch = "";
            row.SonstigeWuensche = "";
            row.BewerberBemerkung = "";
        }

        //Neu nach 23.01.2008
        //----------------------------------------------------------------------------
        /// <summary>
        /// Einen Bewerber löschen
        /// </summary>
        //----------------------------------------------------------------------------
        public void Delete(dsPatientBewerber.PatientRow row)
        {
            if (row == null) return;
            KlientDetails klient = new KlientDetails(row.ID, Guid.Empty);
            
            //Zugeordnete Kontaktpersinen löschen
            foreach (Kontaktperson Kontaktp in klient.KONTAKTPERSONEN)
            {
                Kontaktp.Delete();
                Kontaktp.Write();
            }

            //Zugeordnete Ärzte löschen
            foreach(dsPatientAerzte.PatientAerzteRow r in klient.CLASS_AERZTE.PATIENTAERZTE.PatientAerzte)
                r.Delete();
            klient.CLASS_AERZTE.Write();

            //Zugeordnete Sachwalter löschen
            foreach (Sachwalter sw in klient.LIST_SACHWALTER)
            {
                sw.Delete();
                sw.Write();
            }

            //Zugeordnete Medizinische Daten löschen
            foreach (PMDS.GUI.Klient.dsMedizinischeDaten.MedizinischeDatenRow r in klient.MEDIZINISCHE_DATEN.ALL.MedizinischeDaten)
                r.Delete();
            klient.MEDIZINISCHE_DATEN.Write();

            //Zugeordnete PatientPflegegeldstufen löschen
            foreach(dsKlientPflegestufe.PatientPflegestufeRow r in klient.PATIENTPFLEGESTUFE.ALL.PatientPflegestufe)
                r.Delete();
            klient.PATIENTPFLEGESTUFE.Write();

            //Zugeordnete Rehabilitation löschen
            foreach (dsRehabilitation.RehabilitationRow r in klient.REHABILITATION.ALL.Rehabilitation)
                r.Delete();
            klient.REHABILITATION.Write();

            //Zugeordnete Gegenstände löschen
            foreach (PMDS.GUI.Klient.dsGegenstaende.GegenstaendeRow r in klient.GEGENSTAENDE.ALL.Gegenstaende)
                r.Delete();
            klient.GEGENSTAENDE.Write();

            //Zugeordnete Unterbringung löschen
            foreach (dsUnterbringung.UnterbringungRow r in klient.UNTERBRINGUNG.ALL.Unterbringung)
                r.Delete();
            klient.UNTERBRINGUNG.Write();

            row.Delete();
            Write();
            klient.Adresse.Delete();
            klient.Kontakt.Delete();
        }
    }
}
