using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.GUI.Klient;

namespace PMDS.Klient
{
    public partial class DBSachwalter : Component
    {
        private Guid _idSachwalter = Guid.NewGuid();

        public DBSachwalter()
        {
            InitializeComponent();
        }

        public DBSachwalter(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public Guid IDSachwalter
        {
            get { return _idSachwalter; }
            set { _idSachwalter = value; }
        }

        /// <summary>
        /// Sachwalter Daten
        /// </summary>
        public dsSachwalter SACHWALTER
        {
            get { return dsSachwalter1; }
        }

        /// <summary>
        /// Daten lesen
        /// </summary>
        public void Read()
        {
            SachwalterByFilter();
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            RBU.DataBase.Update(daSachwalter, SACHWALTER.Sachwalter);
        }

        /// <summary>
        /// Daten eines bestimmtes Sachwalter lesen
        /// </summary>
        private void SachwalterByFilter()
        {
            daSachwalter.SelectCommand.Parameters["ID"].Value = IDSachwalter;
            dsSachwalter1.Sachwalter.Rows.Clear();
            RBU.DataBase.Fill(daSachwalter, dsSachwalter1.Sachwalter);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert einen Datatable mit einem neuen Kontaktperson Eintrag
        /// </summary>
        //----------------------------------------------------------------------------
        public void New()
        {
            SACHWALTER.Sachwalter.Clear();
            dsSachwalter.SachwalterRow r = SACHWALTER.Sachwalter.NewSachwalterRow();
            r.ID = Guid.NewGuid();
            r.SachwalterJN = false;
            SACHWALTER.Sachwalter.AddSachwalterRow(r);
        }
    }
}
