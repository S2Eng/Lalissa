using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data.OleDb;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;

namespace PMDS.DB.Global
{
    public partial class DBNachricht : Component
    {
        public DBNachricht()
        {
            InitializeComponent();
        }

        public DBNachricht(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public dsNachricht Nachrichten
        {
            get { return dsNachricht1; }
        }

        public dsNachricht.tbl_NachrichtRow New(Guid IDBenutzerFrom, Guid IDBerufsstandFrom, Guid IDBenutzerTo, Guid IDBerufsstandTo,
                                                Guid IDEintrag, Guid IDPflegePlan, string Nachricht, DateTime StartDatum, int TerminTyp, int EintragsTyp,
                                                DateTime Zeitpunkt)
        {
            dsNachricht.tbl_NachrichtRow r = dsNachricht1.tbl_Nachricht.Newtbl_NachrichtRow();
            r.ID = Guid.NewGuid();
            r.IDBenutzerFrom = IDBenutzerFrom;
            r.IDBerufsstandFrom = IDBerufsstandFrom;
            r.IDBenutzerTo = IDBenutzerTo;
            r.IDBerufsstandTo = IDBerufsstandTo;
            r.IDEintrag = IDEintrag;
            r.IDPflegePlan = IDPflegePlan;
            r.Nachricht = Nachricht;
            r.StartDatum = StartDatum;
            r.TerminTyp = TerminTyp;
            r.EintragsTyp = EintragsTyp;
            r.Zeitpunkt = Zeitpunkt;
            r.Zeitstempel = DateTime.Now;

            dsNachricht1.tbl_Nachricht.Addtbl_NachrichtRow(r);
            return r;
        }

        public void Read(Guid IDBenutzer)
        {
            dsNachricht1.tbl_Nachricht.Clear();
            DataBase.Fill(daNachricht, dsNachricht1.tbl_Nachricht);
        }

        public void Write()
        {
            DataBase.Update(daNachricht, dsNachricht1);
        }

        public dsNachricht.tbl_NachrichtDataTable GetComHistorie(Guid IDBenutzer, Guid IDPflgePlan, Guid IDEintrag, DateTime StartDatum, DateTime Zeitpunkt)
        {
            dsNachricht2.tbl_Nachricht.Clear();
            daComHistorie.SelectCommand.Parameters[0].Value = IDBenutzer;
            daComHistorie.SelectCommand.Parameters[1].Value = IDBenutzer;
            daComHistorie.SelectCommand.Parameters[2].Value = IDPflgePlan;
            daComHistorie.SelectCommand.Parameters[3].Value = IDEintrag;
            daComHistorie.SelectCommand.Parameters[4].Value = StartDatum;
            daComHistorie.SelectCommand.Parameters[5].Value = Zeitpunkt;

            DataBase.Fill(daComHistorie, dsNachricht2.tbl_Nachricht);
            return dsNachricht2.tbl_Nachricht;
        }
    }
}
