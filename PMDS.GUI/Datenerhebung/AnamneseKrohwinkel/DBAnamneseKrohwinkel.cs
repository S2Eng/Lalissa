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



    public partial class DBAnamneseKrohwinkel : Component
    {
        private Guid _idPatient;

        public DBAnamneseKrohwinkel()
        {
            InitializeComponent();
        }

        public DBAnamneseKrohwinkel(IContainer container)
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

        public dsAnamneseKrohwinkel.Anamnese_KrohwinkelDataTable Anamnese_Krohwinkel
        {
            get { return dsAnamneseKrohwinkel1.Anamnese_Krohwinkel; }
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
            //Daten aus der Tabelle Anamnese_Krohwinkel lesen.
            daAnamneseKrohwinkel.SelectCommand.Parameters[0].Value = IDPatient;
            dsAnamneseKrohwinkel1.Anamnese_Krohwinkel.Clear();
            RBU.DataBase.Fill(daAnamneseKrohwinkel, dsAnamneseKrohwinkel1);

            string modell = PflegeModelle.Krohwinkel.ToString();
            //Alle zu Krohwinkel Zugeordneten PDXen aus der Tabellen PDX, PDXPflegemodelle und Pflegemodelle lesen.
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
            daAnamneseKrohwinkel.SelectCommand.Parameters[0].Value = System.Guid.NewGuid();
            dsAnamneseKrohwinkel1.Anamnese_Krohwinkel.Clear();
            RBU.DataBase.Fill(daAnamneseKrohwinkel, dsAnamneseKrohwinkel1);

        }

        public dsAnamneseKrohwinkel.Anamnese_KrohwinkelRow New()
        {
            dsAnamneseKrohwinkel.Anamnese_KrohwinkelRow row = dsAnamneseKrohwinkel1.Anamnese_Krohwinkel.NewAnamnese_KrohwinkelRow();
            row.ID = Guid.NewGuid();
            row.IDPatient = IDPatient;
            row.IDBenutzer = ENV.USERID;
            row.ErstelltAm = DateTime.Now;
            row.ZeitlUrinStuhlKrankheit = 0;
            row.UrinStuhlKrankheit = 0;
            row.ZeitlVerstopfungDurchfallKrakheit = 0;
            row.VerstopfungDurchfallKrakheit = 0;
            dsAnamneseKrohwinkel1.Anamnese_Krohwinkel.AddAnamnese_KrohwinkelRow(row);
            return row;
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            RBU.DataBase.Update(daAnamneseKrohwinkel, dsAnamneseKrohwinkel1);
        }
    }
}
