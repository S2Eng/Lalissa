using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.Datenerhebung2.AnamnesePOP;
using PMDS.BusinessLogic;
using PMDS.GUI.Datenerhebung.AnamnesePOP;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB.Patient
{
    public partial class DBAnamnesePOP : Component
    {
        private Guid _idPatient;
        public dsAnamnesePOP dsAnamnesePOP1 = new dsAnamnesePOP();

        public DBAnamnesePOP()
        {
            InitializeComponent();
        }

        public DBAnamnesePOP(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public Guid IDPatient
        {
            get { return _idPatient; }
            set
            {
                _idPatient = value;
            }
        }

        public dsAnamnesePOP.Anamnese_POPDataTable Anamnese_POP
        {
            get { return dsAnamnesePOP1.Anamnese_POP; }
        }

        public dsPDXByPflegeModell.PDXPflegeModellDataTable PDXByPflegeModell
        {
            get { return dsPDXByPflegeModell1.PDXPflegeModell; }
        }

        public dsPflegemodelle.PflegemodelleDataTable Pflegemodelle
        {
            get { return dsPflegemodelle1.Pflegemodelle; }
        }

        public void Read()
        {
            //Daten aus der Tabelle Anamnese_POP lesen.
            daAnamnesePOP.SelectCommand.Parameters[0].Value = IDPatient;
            dsAnamnesePOP1.Anamnese_POP.Clear();
            RBU.DataBase.Fill(daAnamnesePOP, dsAnamnesePOP1);

            string modell = PflegeModelle.POP.ToString();
            //Alle zu POP Zugeordneten PDXen aus der Tabellen PDX, PDXPflegemodelle und Pflegemodelle lesen.
            daPDXByPflegemodell.SelectCommand.Parameters[0].Value = modell;
            dsPDXByPflegeModell1.PDXPflegeModell.Clear();
            RBU.DataBase.Fill(daPDXByPflegemodell, dsPDXByPflegeModell1.PDXPflegeModell);

            //Daten aus der Tabelle Pflegemodelle
            dsPflegemodelle1.Pflegemodelle.Clear();
            daPflegeModell.SelectCommand.Parameters[0].Value = modell;
            RBU.DataBase.Fill(daPflegeModell, dsPflegemodelle1.Pflegemodelle);
        }
        public void readDummy()
        {
            daAnamnesePOP.SelectCommand.Parameters[0].Value = System.Guid.NewGuid();
            dsAnamnesePOP1.Anamnese_POP.Clear();
            RBU.DataBase.Fill(daAnamnesePOP, dsAnamnesePOP1);
        }

        public dsAnamnesePOP.Anamnese_POPRow New()
        {
            dsAnamnesePOP.Anamnese_POPRow row = dsAnamnesePOP1.Anamnese_POP.NewAnamnese_POPRow();
            PMDS.Data.Global.db.initRow((System.Data.DataRow)row, Guid.NewGuid(), true);
            row.IDPatient = IDPatient;
            row.ErstelltAm = DateTime.Now;
            row.IDBenutzerErstellt = ENV.USERID;

            //Abweichende Initialisierungen
            row.ErnaehrungParenteralEnteral = 2;

            dsAnamnesePOP1.Anamnese_POP.AddAnamnese_POPRow(row);
            return row;
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            RBU.DataBase.Update(daAnamnesePOP, dsAnamnesePOP1);
        }


    }
}
