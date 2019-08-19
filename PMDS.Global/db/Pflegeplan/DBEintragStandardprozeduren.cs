using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Data.PflegePlan;
using RBU;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB.PflegePlan
{
    public partial class DBEintragStandardprozeduren : Component
    {
        public DBEintragStandardprozeduren()
        {
            InitializeComponent();
        }

        public DBEintragStandardprozeduren(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle zugeordnete Standardprozedurren für ein Eintrag
        /// </summary>
        //----------------------------------------------------------------------------
        public dsEintragStandardprozeduren.EintragStandardprozedurenDataTable EintragStProzeduren
        {
            get { return dsEintragStandardprozeduren1.EintragStandardprozeduren; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle zugeordnete Eintäge für eine Standardprozedur
        /// </summary>
        //----------------------------------------------------------------------------
        public dsEintragStandardprozeduren.EintragStandardprozedurenDataTable EintragStdProzedurenByIDStdProz
        {
            get { return dsEintragStandardprozeduren2.EintragStandardprozeduren; }
        }

        public void Read(Guid IDEintrag)
        {
            dsEintragStandardprozeduren1.EintragStandardprozeduren.Clear();
            daStProzedByEintrag.SelectCommand.Parameters[0].Value = IDEintrag;
            DataBase.Fill(daStProzedByEintrag, dsEintragStandardprozeduren1);
        }

        public void ReadByStandardprozedur(Guid IDStandardProzedur)
        {
            dsEintragStandardprozeduren2.EintragStandardprozeduren.Clear();
            daStdProzByStandardProz.SelectCommand.Parameters[0].Value = IDStandardProzedur;
            DataBase.Fill(daStdProzByStandardProz, dsEintragStandardprozeduren2);
        }

        public dsEintragStandardprozeduren.EintragStandardprozedurenRow New(Guid IDEintrag, Guid IDStandardProzeduren)
        {
            dsEintragStandardprozeduren.EintragStandardprozedurenRow row = dsEintragStandardprozeduren1.EintragStandardprozeduren.NewEintragStandardprozedurenRow();
            row.ID = Guid.NewGuid();
            row.IDEintrag = IDEintrag;
            row.IDStandardProzeduren = IDStandardProzeduren;

            dsEintragStandardprozeduren1.EintragStandardprozeduren.AddEintragStandardprozedurenRow(row);
            return row;
        }

        public void DeleteZuordnungen()
        {
            foreach (dsEintragStandardprozeduren.EintragStandardprozedurenRow row in dsEintragStandardprozeduren1.EintragStandardprozeduren)
                row.Delete();

            Write();
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            DataBase.Update(daStProzedByEintrag, dsEintragStandardprozeduren1);
        }
    }
}
