using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Data.Global;
using PMDS.DB.Global;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{
    public class Nachricht
    {
        private DBNachricht _db;
        public Nachricht()
        {
            _db = new DBNachricht();
        }

        public dsNachricht Nachrichten
        {
            get { return _db.Nachrichten; }
        }

        public dsNachricht.tbl_NachrichtRow New(Guid IDBenutzerFrom, Guid IDBerufsstandFrom, Guid IDBenutzerTo, Guid IDBerufsstandTo,
                                                Guid IDEintrag, Guid IDPflegePlan, string Nachricht, DateTime StartDatum, int TerminTyp, int EintragsTyp,
                                                DateTime Zeitpunkt)
        {
            return _db.New(IDBenutzerFrom, IDBerufsstandFrom, IDBenutzerTo, IDBerufsstandTo,
                           IDEintrag, IDPflegePlan, Nachricht, StartDatum, TerminTyp, EintragsTyp, Zeitpunkt);
        }

        public void Read(Guid IDBenutzer)
        {
            _db.Read(IDBenutzer);
        }

        public void Write()
        {
            _db.Write();
        }

        public dsNachricht.tbl_NachrichtDataTable GetComHistorie(Guid IDBenutzer, Guid IDPflgePlan, Guid IDEintrag, DateTime StartDatum, DateTime Zeitpunkt)
        {
            return _db.GetComHistorie(IDBenutzer, IDPflgePlan, IDEintrag, StartDatum, Zeitpunkt);
        }
    }
}
