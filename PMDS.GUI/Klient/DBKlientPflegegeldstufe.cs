using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.GUI.Klient;

namespace PMDS.Klient
{



    public partial class DBKlientPflegegeldstufe : Component
    {
        public DBKlientPflegegeldstufe()
        {
            InitializeComponent();
        }

        public DBKlientPflegegeldstufe(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Alle Pflegegeldstufen
        /// </summary>
        public dsKlientPflegegeldstufe ALL
        {
            get { return dsKlientPflegegeldstufe1; }
        }

        /// <summary>
        /// Alle Pflegegeldstufen einlesen
        /// </summary>
        public void Read()
        {
            RBU.DataBase.Fill(daPflegegeldstufe, dsKlientPflegegeldstufe1);
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            RBU.DataBase.Update(daPflegegeldstufe, dsKlientPflegegeldstufe1);
        }

        /// <summary>
        /// Neue Pflegegeldstufe einfügen
        /// </summary>
        public void New()
        {
            dsKlientPflegegeldstufe.PflegegeldstufeRow r = dsKlientPflegegeldstufe1.Pflegegeldstufe.NewPflegegeldstufeRow();
            r.ID = Guid.NewGuid();
            dsKlientPflegegeldstufe1.Pflegegeldstufe.AddPflegegeldstufeRow(r);
        }
    }
}
