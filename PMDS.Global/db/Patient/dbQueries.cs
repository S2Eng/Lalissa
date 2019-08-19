using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMDS.Global.db.Patient;
using PMDS.Data.Patient ;
using PMDS.Global.db.Patient.dsAnamnesenTableAdapters;
using System.Data;

namespace PMDS.Data.Patient
{

    public class dbQueries_os
    {

        public dsAnamnesen.AnamnesenProPatientDataTable GetAllAnamnesenProPatient(System.Guid IDKlient)
        {
            dsAnamnesen.AnamnesenProPatientDataTable dt = new dsAnamnesen.AnamnesenProPatientDataTable();

            AnamnesenProPatientTableAdapter ta = new AnamnesenProPatientTableAdapter();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            ta.Connection = RBU.DataBase.CONNECTION;

            dt = ta.GetAllKrowinkelByPatient(IDKlient);
            dt = ta.GetAllOremByPatient(IDKlient);
            return dt;
        }

        public dsAnamnesen.FormularDatenDataTable GetAllAssessmentsProPatient(System.Guid IDKlient)
        {
            dsAnamnesen.FormularDatenDataTable dt = new dsAnamnesen.FormularDatenDataTable();

            FormularDatenTableAdapter ta = new FormularDatenTableAdapter();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            ta.Connection = RBU.DataBase.CONNECTION;

            dt = ta.GetAllFormulareByPatient(IDKlient);
            return dt;
                       

        }

    }

}


