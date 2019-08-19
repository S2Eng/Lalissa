using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PMDS.DB.Patient;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.Datenerhebung2.AnamnesePOP;
using PMDS.GUI.Datenerhebung.AnamnesePOP;



namespace PMDS.BusinessLogic
{
    public class AnamnesePOP : IAnamneseObject
    {
        private DBAnamnesePOP _db;
        private PDXAnamnese _PDXAnamnese;
        private Guid _idPatient;

        public AnamnesePOP()
        {
            _db = new DBAnamnesePOP();
            _PDXAnamnese = new PDXAnamnese(PflegeModelle.POP);
        }

        public AnamnesePOP(Guid idPatient)
        {
            _db = new DBAnamnesePOP();
            _PDXAnamnese = new PDXAnamnese(PflegeModelle.POP);
            _idPatient = idPatient;
            _db.IDPatient = idPatient;
            Read();
        }

        public PDXAnamnese PDXAnamnese
        {
            get { return _PDXAnamnese; }
            set { _PDXAnamnese = value; }
        }

        public Guid IDPatient
        {
            get { return _idPatient; }
            set
            {
                _idPatient = value;
                _db.IDPatient = value;
                Read();
            }
        }

        public DataRow New()
        {
            return _db.New();
        }

        public void Read()
        {
            _db.Read();
            _PDXAnamnese.ReadByModell();
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            _db.Write();
            _PDXAnamnese.Write();
        }

        public void Refresh()
        {
            _db = new DBAnamnesePOP();
            _PDXAnamnese = new PDXAnamnese(PflegeModelle.POP);
            _db.IDPatient = _idPatient;
            Read();
        }

        public DataTable AnamneseDataTable
        {
            get { return _db.Anamnese_POP; }
        }

        public DataTable PDXByPflegeModell
        {
            get { return _db.PDXByPflegeModell; }
        }

        public DataTable Pflegemodelle
        {
            get { return _db.Pflegemodelle; }
        }

        public DataTable PDXAnamneseDataTable
        {
            get { return _PDXAnamnese.PDXAnamneseDataTable; }
        }

        public DataRow GetAnamneseRow(Guid id)
        {
            dsAnamnesePOP.Anamnese_POPRow row = null;
            foreach (dsAnamnesePOP.Anamnese_POPRow r in _db.Anamnese_POP)
            {
                if (r.RowState != System.Data.DataRowState.Deleted && r.ID == id)
                {
                    row = r;
                    break;
                }
            }

            return row;
        }

        public Guid GetIDBenutzer(Guid IDAnamnese)
        {
            Guid IDBenutzer = Guid.Empty;

            foreach (dsAnamnesePOP.Anamnese_POPRow r in _db.Anamnese_POP)
            {
                if (r.RowState != System.Data.DataRowState.Deleted && r.ID == IDAnamnese)
                {
                    IDBenutzer = r.IDBenutzerErstellt;
                    break;
                }
            }

            return IDBenutzer;
        }

        public void UpdateDATA(Guid IDAnamnese, DateTime ErstelltAm, Guid IDBenutzer)
        {
            dsAnamnesePOP.Anamnese_POPRow r = (dsAnamnesePOP.Anamnese_POPRow)GetAnamneseRow(IDAnamnese);
            r.ErstelltAm = ErstelltAm;
            r.IDBenutzerErstellt = IDBenutzer;
        }
    }
}
