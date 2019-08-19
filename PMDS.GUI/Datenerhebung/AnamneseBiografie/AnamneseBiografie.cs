using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PMDS.DB.Patient;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.GUI.Datenerhebung.AnamneseBiografie;



namespace PMDS.BusinessLogic
{
    public class AnamneseBiografie : IAnamneseObject
    {
        private DBAnamneseBiografie _db;
        private PDXAnamnese _PDXAnamnese;
        private Guid _idPatient;

        public AnamneseBiografie()
        {
            _db = new DBAnamneseBiografie();
            _PDXAnamnese = new PDXAnamnese(PflegeModelle.Biografie );
        }

        public AnamneseBiografie(Guid idPatient)
        {
            _db = new DBAnamneseBiografie();
            _PDXAnamnese = new PDXAnamnese(PflegeModelle.Biografie);
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
            _db = new DBAnamneseBiografie ();
            _PDXAnamnese = new PDXAnamnese(PflegeModelle.Biografie );
            _db.IDPatient = _idPatient;
            Read();
        }

        public DataTable AnamneseDataTable
        {
            get { return _db.Anamnese_Biografie   ; }
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
            PMDS.GUI.Datenerhebung.AnamneseBiografie.dsAnamneseBiografie2.Anamnese_BiografieRow row = null;
            foreach (PMDS.GUI.Datenerhebung.AnamneseBiografie.dsAnamneseBiografie2.Anamnese_BiografieRow r in _db.Anamnese_Biografie)
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

            foreach (PMDS.GUI.Datenerhebung.AnamneseBiografie.dsAnamneseBiografie2.Anamnese_BiografieRow r in _db.Anamnese_Biografie)
            {
                if (r.RowState != System.Data.DataRowState.Deleted && r.ID == IDAnamnese)
                {
                    IDBenutzer = r.IDBenutzer;
                    break;
                }
            }
            
            return IDBenutzer;
        }

        public void UpdateDATA(Guid IDAnamnese, DateTime ErstelltAm, Guid IDBenutzer)
        {
            dsAnamneseKrohwinkel.Anamnese_KrohwinkelRow r = (dsAnamneseKrohwinkel.Anamnese_KrohwinkelRow)GetAnamneseRow(IDAnamnese);
            r.ErstelltAm = ErstelltAm;
            r.IDBenutzer = IDBenutzer;
        }
    }
}
