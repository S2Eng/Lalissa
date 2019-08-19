using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.GUI.Klient;




namespace PMDS.Klient
{


    public partial class DBKlientPflegestufe : Component
    {

        private Guid _idPatient = Guid.NewGuid();

        

        public DBKlientPflegestufe()
        {
            InitializeComponent();
        }
        public DBKlientPflegestufe(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }




        public Guid IDpatient
        {
            get { return _idPatient; }
            set { _idPatient = value; }
        }

        public  dsKlientPflegestufe ALL
        {
            get { return dsPatientPflegestufe1; }
        }

        public void Read()
        {
            daPatientPflegestufe.SelectCommand.Parameters[0].Value = _idPatient;
            RBU.DataBase.Fill(daPatientPflegestufe, dsPatientPflegestufe1);
        }

        public void Write()
        {
            RBU.DataBase.Update(daPatientPflegestufe, dsPatientPflegestufe1);
        }

        public void New(object pflegestufe, DateTime gueltigAb, DateTime antragsdatum, object beantragtePflagestufe,
                        DateTime bescheiddatum)
        {
            dsKlientPflegestufe.PatientPflegestufeRow r = dsPatientPflegestufe1.PatientPflegestufe.NewPatientPflegestufeRow();
            r.ID = Guid.NewGuid();
            r.IDPatient = IDpatient;
            r.IDPflegegeldstufe = new Guid(pflegestufe.ToString());
            r.BetragVerwendbar = 0;
            r.GutschriftProTagAbwesend = 0;
            r.GueltigAb = gueltigAb;

            if (antragsdatum != DateTime.MinValue)
                r.AenderungsantragDatum = antragsdatum;
            else
                r.SetAenderungsantragDatumNull();

            if(beantragtePflagestufe != null)
                r.IDPflegegeldstufeAntrag = new Guid(beantragtePflagestufe.ToString());

            if (bescheiddatum != DateTime.MinValue)
                r.GenehmigungDatum = bescheiddatum;
            else
                r.SetGenehmigungDatumNull();
            r.SetGueltigBisNull();
        
            dsPatientPflegestufe1.PatientPflegestufe.AddPatientPflegestufeRow(r);
        }

    }

}
