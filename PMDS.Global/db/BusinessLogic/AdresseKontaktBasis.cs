using System;
using System.Data;
using System.Data.OleDb;

using PMDS.Global;




namespace PMDS.BusinessLogic
{

    abstract public class AdresseKontaktBasis : BusinessBase, IBusinessBase
    {
        private Adresse _Adresse;
        private Kontakt _Kontakt;

        public AdresseKontaktBasis()
        {
        }

        #region PROPERTIES
        public abstract Guid IDAdresse
        {
            get;
            set;
        }
        public abstract Guid IDKontakt
        {
            get;
            set;
        }
        #endregion


        private void Reset()
        {
            _Adresse = null;
            _Kontakt = null;
        }

        private void InitAdresse()
        {
            // Adresse bereits vorhanden
            if (_Adresse != null)
                return;

            // neue Adresse ?
            if (IDAdresse == Guid.Empty)
            {
                _Adresse = new Adresse();
                IDAdresse = _Adresse.ID;
            }
            else
            {
                _Adresse = new Adresse(IDAdresse);
            }
        }

        private void InitKontakt()
        {
            if (_Kontakt != null)
                return;

            // neue Kontakt ?
            if (IDKontakt == Guid.Empty)
            {
                _Kontakt = new Kontakt();
                IDKontakt = _Kontakt.ID;
            }
            else
            {
                _Kontakt = new Kontakt(IDKontakt);
            }
        }

        public Adresse Adresse
        {
            get
            {
                InitAdresse();
                return _Adresse;
            }
        }
        public Kontakt Kontakt
        {
            get
            {
                InitKontakt();
                return _Kontakt;
            }
        }
        public override void New()
        {
            Reset();
            base.New();
        }
        public override void Read()
        {
            Reset();
            base.Read();
        }
        public override void Write()
        {
            Adresse.Write();
            Kontakt.Write();

            base.Write();
        }
        public override void Delete()
        {
            base.Delete();

            Adresse.Delete();
            Kontakt.Delete();
        }
    }
}
