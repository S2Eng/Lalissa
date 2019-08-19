using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Global.db.Patient;
using PMDS.Klient;

namespace PMDS.BusinessLogic
{
    public class KlientKlinik
    {
        private DBKlinik _db;
        private Guid _idAufenthalt;

        public KlientKlinik()
        {
            _db = new DBKlinik();
        }

        public KlientKlinik(Guid idAufenthalt)
        {
            _db = new DBKlinik();
            _idAufenthalt = idAufenthalt;
            _db.IDAufenthalt = idAufenthalt;
        }

        public Guid IDAufenthalt
        {
            get { return _idAufenthalt; }
            set
            {
                _idAufenthalt = value;
                _db.IDAufenthalt = value;
            }
        }

        public dsKlinik KlinikByAufenthalt
        {
            get { return _db.KlinikByAufenthalt; }
        }

    }
}
