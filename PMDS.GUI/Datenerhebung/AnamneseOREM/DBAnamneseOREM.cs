using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB.Patient
{
    public partial class DBAnamneseOREM : Component
    {
        private Guid _idPatient;

        public DBAnamneseOREM()
        {
            InitializeComponent();
        }

        public DBAnamneseOREM(IContainer container)
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

        public dsAnamneseOrem.Anamnese_OremDataTable Anamnese_OREM
        {
            get { return dsAnamneseOrem1.Anamnese_Orem; }
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
            //Daten aus der Tabelle Anamnese_Orem lesen.
            daAnamneseOREM.SelectCommand.Parameters[0].Value = IDPatient;
            dsAnamneseOrem1.Anamnese_Orem.Clear();
            RBU.DataBase.Fill(daAnamneseOREM, dsAnamneseOrem1);

            string modell = PflegeModelle.Orem.ToString();
            //Alle zu Orem Zugeordneten PDXen aus der Tabellen PDX, PDXPflegemodelle und Pflegemodelle lesen.
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
            daAnamneseOREM.SelectCommand.Parameters[0].Value = System.Guid.NewGuid();
            dsAnamneseOrem1.Anamnese_Orem.Clear();
            RBU.DataBase.Fill(daAnamneseOREM, dsAnamneseOrem1);

        }

        public dsAnamneseOrem.Anamnese_OremRow New()
        {
            dsAnamneseOrem.Anamnese_OremRow row = dsAnamneseOrem1.Anamnese_Orem.NewAnamnese_OremRow();
            row.ID = Guid.NewGuid();
            row.IDPatient = IDPatient;
            row.IDBenutzerErstellt = ENV.USERID;
            row.ErstelltAm = DateTime.Now;
            dsAnamneseOrem1.Anamnese_Orem.AddAnamnese_OremRow(row);
            return row;
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            RBU.DataBase.Update(daAnamneseOREM, dsAnamneseOrem1);
        }


    }
}
