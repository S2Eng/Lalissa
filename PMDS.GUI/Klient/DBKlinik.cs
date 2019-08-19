using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Global.db.Patient;



namespace PMDS.Klient
{


    public partial class DBKlinik : Component
    {
        private Guid _idAufenthalt;

        public DBKlinik()
        {
            InitializeComponent();
        }

        public DBKlinik(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public Guid IDAufenthalt
        {
            get { return _idAufenthalt; }
            set
            {
                _idAufenthalt = value;
                Read();
            }
        }

        public dsKlinik KlinikByAufenthalt
        {
            get { return dsKlinikByAufenthalt; }
        }

        public void Read()
        {
            dsKlinikByAufenthalt.Klinik.Clear();
            daKlinikByAufenthalt.SelectCommand.Parameters[0].Value = IDAufenthalt;
            RBU.DataBase.Fill(daKlinikByAufenthalt, dsKlinikByAufenthalt);
        }
    }
}
