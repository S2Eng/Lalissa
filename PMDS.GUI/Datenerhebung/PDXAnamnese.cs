using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB.Patient;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{
    public class PDXAnamnese
    {
        private DBPDXAnamnese _db;
        private PflegeModelle _pflegemodell;

        public PDXAnamnese()
        {
            _db = new DBPDXAnamnese();
        }

        public PDXAnamnese(PflegeModelle PflegeModell)
        {
            _pflegemodell = PflegeModell;
            _db = new DBPDXAnamnese();
        }

        public PflegeModelle PflegeModell
        {
            get { return _pflegemodell; }
            set { _pflegemodell = value; }
        }

        public dsPDXAnamnese.PDXAnamneseDataTable PDXAnamneseDataTable
        {
            get { return _db.PDXAnamneseDataTable; }
        }

        public void Read()
        {
            _db.Read();
        }

        public void ReadByModell()
        {
            _db.ReadByModell(PflegeModell);
        }

        public dsPDXAnamnese.PDXAnamneseRow New()
        {
            return _db.New();
        }

        //Änderung nach 11.05.2007 MDA
        public void NewPDXAnamnese(int Modellgruppe, Guid IDAnamnese, Guid IDPDX, string Resourceklient)
        {
            _db.NewPDXAnamnese(PflegeModell, Modellgruppe, IDAnamnese, IDPDX, Resourceklient);
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            _db.Write();
        }

        public dsIDTextBezeichnung GetAllAnamnesen(Guid IDPatient)
        {
            return _db.GetAllAnamnesen(IDPatient);
        }

        public bool FindPDX(Guid IDPDX)
        {
            foreach (dsPDXAnamnese.PDXAnamneseRow r in PDXAnamneseDataTable)
            {
                if (r.IDPDX == IDPDX)
                    return true;
            }

            return false;
        }
    }
}
