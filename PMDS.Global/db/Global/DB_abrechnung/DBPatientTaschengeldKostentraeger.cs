using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global.ds_abrechnung;

namespace PMDS.DB.Global
{
    public partial class DBPatientTaschengeldKostentraeger : Component
    {
        public DBPatientTaschengeldKostentraeger()
        {
            InitializeComponent();
        }

        public DBPatientTaschengeldKostentraeger(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Alle Datenaätze
        /// </summary>
        /// <returns></returns>
        public dsPatientTaschengeldKostentraeger Read()
        {
            dsPatientTaschengeldKostentraeger ds = new dsPatientTaschengeldKostentraeger();
            DataBase.Fill(daAllEntries, ds.PatientTaschengeldKostentraeger);
            return ds;
        }

        public dsPatientTaschengeldKostentraeger Read(Guid IDPatient)
        {
            dsPatientTaschengeldKostentraeger ds = new dsPatientTaschengeldKostentraeger();
            daPatientTaschengeldKostentraeger.SelectCommand.Parameters[0].Value = IDPatient;
            DataBase.Fill(daPatientTaschengeldKostentraeger, ds.PatientTaschengeldKostentraeger);
            return ds;
        }

        public void Update(dsPatientTaschengeldKostentraeger ds)
        {
            DataBase.Update(daAllEntries, ds.PatientTaschengeldKostentraeger);
        }
    }
}
