using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.GUI.Klient;

namespace PMDS.Klient
{
    
    public partial class DBKontaktperson : Component
    {
        private Guid _idKontaktperson = Guid.NewGuid();





        public DBKontaktperson()
        {
            InitializeComponent();
        }
        
        public DBKontaktperson(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }




        public Guid IDKontaktperson
        {
            get { return _idKontaktperson; }
            set { _idKontaktperson = value; }
        }

        /// <summary>
        /// Kontaktperson Daten
        /// </summary>
        public dsKontaktperson KOTAKTPERSON
        {
            get { return dsKontaktperson1; }
        }

        /// <summary>
        /// Daten lesen
        /// </summary>
        public void Read()
        {
            KontaktpersonByFilter();
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            RBU.DataBase.Update(daKontaktperson, KOTAKTPERSON.Kontaktperson);
        }

        /// <summary>
        /// Daten eines bestimmtes Kontaktperson lesen
        /// </summary>
        private void KontaktpersonByFilter()
        {
            daKontaktperson.SelectCommand.Parameters["ID"].Value = IDKontaktperson;
            dsKontaktperson1.Kontaktperson.Rows.Clear();
            RBU.DataBase.Fill(daKontaktperson, dsKontaktperson1.Kontaktperson);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert einen Datatable mit einem neuen Kontaktperson Eintrag
        /// </summary>
        //----------------------------------------------------------------------------
        public void New()
        {
            KOTAKTPERSON.Kontaktperson.Rows.Clear();
            dsKontaktperson.KontaktpersonRow r = KOTAKTPERSON.Kontaktperson.NewKontaktpersonRow();
            r.ID = Guid.NewGuid();
            r.IDPatient = Guid.NewGuid();
            r.ExternerDienstleisterJN = false;
            r.VerstaendigenJN = false;
            KOTAKTPERSON.Kontaktperson.AddKontaktpersonRow(r);
        }
    }
}
