using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Global;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Global.db.Global;

namespace PMDS.DB.Global
{


    public partial class DBTaschengeld : Component
    {


        public DBTaschengeld()
        {
            InitializeComponent();
        }

        public DBTaschengeld(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public dsTaschengeld TASCHENGELD
        {
            get { return dsTaschengeld1; }
        }

        public void Read(Guid IDPatient, DateTime von, DateTime bis,  System.Guid IDKlinik)
        {
            dsTaschengeld1.Taschengeld.Clear();
            daTaschengeldByPatient.SelectCommand.Parameters[0].Value = IDPatient;
            daTaschengeldByPatient.SelectCommand.Parameters[1].Value = von;
            daTaschengeldByPatient.SelectCommand.Parameters[2].Value = bis;
            daTaschengeldByPatient.SelectCommand.Parameters[3].Value = IDKlinik;
            DataBase.Fill(daTaschengeldByPatient, dsTaschengeld1.Taschengeld);
        }

        public void Write()
        {
            daTaschengeldByPatient.Update(dsTaschengeld1.Taschengeld );
        }

        public dsTaschengeld.TaschengeldRow New(Guid IDPatient, DateTime Datum, System.Guid  IDKlinik)
        {
            dsTaschengeld.TaschengeldRow row = dsTaschengeld1.Taschengeld.NewTaschengeldRow();
            row.ID = Guid.NewGuid();
            row.IDPatient = IDPatient;
            row.IDBenutzerdurchgefuehrt = ENV.USERID;
            row.Datum = Datum;
            row.AbgerechnetJN = false;
            row.IDKlinik = IDKlinik;

            dsTaschengeld1.Taschengeld.AddTaschengeldRow(row);
            return row;
        }

        //Neu nach 18.02.2008 MDA
        public dsGUIDListe.IDListeDataTable GetListKostentraeger(Guid IDPatient,System.Guid IDKlinik)
        {
            dsGUIDListe.IDListeDataTable dt = new dsGUIDListe.IDListeDataTable();
            daKostentraeger.SelectCommand.Parameters[0].Value = IDPatient;
            daKostentraeger.SelectCommand.Parameters[1].Value = IDKlinik;
            DataBase.Fill(daKostentraeger, dt);
            return dt;
        }
    }
}
