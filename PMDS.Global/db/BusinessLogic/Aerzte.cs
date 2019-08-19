using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PMDS.Data.Global;
using PMDS.DB.Global;
using PMDS.Global.db.Global;
using PMDS.DB;
using PMDS.Global.db.Patient;
using System.Linq;

namespace PMDS.BusinessLogic
{

    public class Aerzte
    {

        private DBAerzte _db;
        private DBPatientAerzte _DBPatientAerzte;
        public List<Arzt> _ListAerzte;
        private Guid _IDPatient = Guid.Empty;

        public bool _doAllAdresseKontakte2 = false;
        public dsAdresse.AdresseDataTable dtAdresse = new dsAdresse.AdresseDataTable();
        public DBAdresse _dbAdresse = new DBAdresse();
        public dsKontakt.KontaktDataTable dtKontakt = new dsKontakt.KontaktDataTable();
        public DBKontakt _dbKontakt = new DBKontakt();

        





        public Aerzte()
        {
            _db = new DBAerzte();
            _DBPatientAerzte = new DBPatientAerzte();
            _ListAerzte = new List<Arzt>();
        }

        public Guid IDPatient
        {
            get { return _IDPatient; }
            set { _IDPatient = value; }
        }

        public dsAerzte AERZTE
        {
            get { return _db.Aerzte; }
        }

        public dsPatientAerzte PATIENTAERZTE
        {
            get { return _DBPatientAerzte.PatientAerzte; }
        }

        public dsPatientAerzte ALLAKTIVEPATIENTHAUSAERZTE
        {
            get { return _DBPatientAerzte.AllAktivePatientHausAerzte; }
        }

        public dsGUIDListe ALLAKTIVEPATIENTHAUSAERZTEBYPatient(Guid IDPatient)
        {
             return _DBPatientAerzte.AllAktivePatientHausAerzteByPatient(IDPatient);
        }



        public void Read()
        {
            _db.Read();
            FillListAerzte(this._doAllAdresseKontakte2);
        }

        public void ReadByPatient(Guid IdPatient)
        {
            _IDPatient = IdPatient;
            _DBPatientAerzte.Read(IdPatient);
        }




        public dsAerzte.AerzteRow New()
        {
            dsAerzte.AerzteRow row = _db.New();

            Arzt arzt = new Arzt(row.ID, Guid.Empty, Guid.Empty);
            row.IDAdresse = arzt.Adresse.ID;
            row.IDKontakt = arzt.Kontakt.ID;
            _ListAerzte.Add(arzt);
            return row;
        }

        public dsPatientAerzte.PatientAerzteRow NewPatientAerzte(Guid IDAerzte)
        {
            return _DBPatientAerzte.New(IDPatient, IDAerzte);
        }

        public void DeleteAerzte(dsAerzte.AerzteRow[] Rows)
        {
            Arzt arzt;
            foreach (dsAerzte.AerzteRow r in Rows)
            {
                arzt = GetArzt(r.ID);
                arzt.Delete();
                r.Delete();
            }
        }

        public void Write()
        {
            if (_doAllAdresseKontakte2)
            {
                foreach (Arzt arzt in _ListAerzte)
                {
                    if (arzt.Adresse._db.dsAdresse1.Adresse[0].RowState == DataRowState.Modified)
                    {
                        dsAdresse.AdresseRow rAdresseUI = (from adr in arzt.Adresse._db.dsAdresse1.Adresse where adr.ID == arzt.Adresse._db.dsAdresse1.Adresse[0].ID select adr).FirstOrDefault();
                        dsAdresse.AdresseRow rAdresseUpdate = (from adr in this.dtAdresse where adr.ID == arzt.IDAdresse select adr).FirstOrDefault();

                        rAdresseUpdate.Strasse = rAdresseUI.Strasse.Trim();
                        rAdresseUpdate.Plz = rAdresseUI.Plz.Trim();
                        rAdresseUpdate.Ort = rAdresseUI.Ort.Trim();
                        rAdresseUpdate.LandKZ = rAdresseUI.LandKZ.Trim();
                    }
                    if (arzt.Kontakt._db.dsKontakt1.Kontakt[0].RowState == DataRowState.Modified)
                    {
                        dsKontakt.KontaktRow rKontaktUI = (from kont in arzt.Kontakt._db.dsKontakt1.Kontakt where kont.ID == arzt.Kontakt._db.dsKontakt1.Kontakt[0].ID select kont).First();
                        dsKontakt.KontaktRow rKontaktUpdate = (from kont in this.dtKontakt where kont.ID == arzt.IDKontakt select kont).FirstOrDefault();

                        rKontaktUpdate.Tel = rKontaktUI.Tel.ToString();
                        rKontaktUpdate.Mobil = rKontaktUI.Mobil.ToString();
                        rKontaktUpdate.Fax = rKontaktUI.Fax.ToString();
                        rKontaktUpdate.Email = rKontaktUI.Email.ToString();
                        rKontaktUpdate.Andere = rKontaktUI.Andere.ToString();
                        rKontaktUpdate.Ansprechpartner = rKontaktUI.Ansprechpartner.ToString();
                        rKontaktUpdate.Zusatz1 = rKontaktUI.Zusatz1.ToString();
                        rKontaktUpdate.Zusatz2 = rKontaktUI.Zusatz2.ToString();
                        rKontaktUpdate.Zusatz3 = rKontaktUI.Zusatz3.ToString();
                    }

                    this._dbAdresse.daAdresseWhere.Update(this.dtAdresse);
                    this._dbKontakt.daKontakteWhere.Update(this.dtKontakt);
                }

                _db.Write();
                _DBPatientAerzte.Write();
            }
            else
            {
                foreach (Arzt arzt in _ListAerzte)
                {
                    if (!arzt.DELETED)
                    {
                        arzt.Adresse.Write();
                        arzt.Kontakt.Write();
                    }
                }

                _db.Write();
                _DBPatientAerzte.Write();

                foreach (Arzt arzt in _ListAerzte)
                {
                    if (arzt.DELETED)
                    {
                        arzt.Adresse.Delete();
                        arzt.Kontakt.Delete();
                    }
                }
            }
        }

        private void FillListAerzte(bool _doAllAdresseKontakte)
        {
            _ListAerzte.Clear();

            if (_doAllAdresseKontakte)
            {
                string sWhereAdresse = "";
                string sWhereKontakt = "";
                foreach (dsAerzte.AerzteRow r in AERZTE.Aerzte)             //os-Perfomance !!!
                {
                    if (!r.IsIDAdresseNull())
                        sWhereAdresse += (sWhereAdresse.Trim() == "" ? " where " : " or ") + " ID='" + r.IDAdresse.ToString() + "' ";
                    if (!r.IsIDKontaktNull())
                        sWhereKontakt += (sWhereKontakt.Trim() == "" ? " where " : " or ") + " ID='" + r.IDKontakt.ToString() + "' ";
                }

                dtAdresse = new dsAdresse.AdresseDataTable();
                _dbAdresse = new DBAdresse();
                _dbAdresse.loadAdressenWhere(sWhereAdresse, ref dtAdresse);

                dtKontakt = new dsKontakt.KontaktDataTable();
                _dbKontakt = new DBKontakt();
                _dbKontakt.loadKontakteWhere(sWhereKontakt, ref dtKontakt);

                Arzt arzt;
                foreach (dsAerzte.AerzteRow r in AERZTE.Aerzte)             //os-Perfomance !!!
                {
                    System.Data.EnumerableRowCollection<dsAdresse.AdresseRow> arrAdresseDS = (from adr in dtAdresse where adr.ID == r.IDAdresse select adr);
                    System.Data.EnumerableRowCollection<dsKontakt.KontaktRow> arrKontaktDS = (from kont in dtKontakt where kont.ID == r.IDKontakt select kont);

                    arzt = new Arzt(r.ID, arrAdresseDS, arrKontaktDS);
                    //arzt = new Arzt(r.ID, r.IDAdresse, r.IDKontakt);
                    _ListAerzte.Add(arzt);
                }

                bool bAerzteDone = true;
            }
            else
            {
                Arzt arzt = null;
                foreach (dsAerzte.AerzteRow r in AERZTE.Aerzte)             //os-Perfomance !!!
                {
                    arzt = new Arzt(r.ID, r.IDAdresse, r.IDKontakt);
                    _ListAerzte.Add(arzt);
                }
            }

        }

        public Arzt GetArzt(Guid IDArzt)
        {
            Arzt arzt = null;

            foreach (Arzt a in _ListAerzte)
            {
                if (a.ID == IDArzt)
                {
                    arzt = a;
                    break;
                }
            }

            return arzt;
        }

        /// ID alle Ärzte eines Patienten zurückgeben
        public Guid[] GetPatientAerzte()
        {
            List<Guid> list = new List<Guid>();

            foreach (dsPatientAerzte.PatientAerzteRow r in PATIENTAERZTE.PatientAerzte)
                if (r.RowState != DataRowState.Deleted)
                    list.Add(r.IDAerzte);

            return list.ToArray();

        }    

        public static bool IsRezeptErstellt(Guid IDPatient, Guid IDAerzte)
        {
            return DBAerzte.IsRezeptErstellt(IDPatient, IDAerzte);
        }

        public static dsAerzte.AerzteRow GetArztDetails(Guid IdArzt)
        {
            return DBAerzte.GetArztDetails(IdArzt);
        }
        public static string GetArztName(Guid IdArzt)
        {
            return DBAerzte.GetArztName(IdArzt);
        }

    }
}
