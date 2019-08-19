using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using RBU;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB.Patient
{
    public partial class DBAnamneseBiografie : Component
    {
        private Guid _idPatient;

        public DBAnamneseBiografie()
        {
            InitializeComponent();
        }

        public DBAnamneseBiografie(IContainer container)
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

        public PMDS.GUI.Datenerhebung.AnamneseBiografie.dsAnamneseBiografie2.Anamnese_BiografieDataTable Anamnese_Biografie
        {
            get { return dsAnamneseBiografie1.Anamnese_Biografie  ; }
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
            ////Daten aus der Tabelle Biografie lesen.
            //daAnamneseKrohwinkel.SelectCommand.Parameters[0].Value = IDPatient;
            //dsAnamneseKrohwinkel1.Anamnese_Krohwinkel.Clear();
            //DataBase.Fill(daAnamneseKrohwinkel, dsAnamneseKrohwinkel1);

            string modell = PflegeModelle.Biografie .ToString();
            //Alle zu Krohwinkel Zugeordneten PDXen aus der Tabellen PDX, PDXPflegemodelle und Pflegemodelle lesen.
            daPDXByPflegemodell.SelectCommand.Parameters[0].Value = modell;
            dsPDXByPflegeModell1.PDXPflegeModell.Clear();
            DataBase.Fill(daPDXByPflegemodell, dsPDXByPflegeModell1.PDXPflegeModell);

            //Daten aus der Tabelle Pflegemodelle
            dsPflegemodelle1.Pflegemodelle.Clear();
            daPflegeModell.SelectCommand.Parameters[0].Value = modell;
            DataBase.Fill(daPflegeModell, dsPflegemodelle1.Pflegemodelle);
        }

        public PMDS.GUI.Datenerhebung.AnamneseBiografie.dsAnamneseBiografie2.Anamnese_BiografieRow New()
        {
            PMDS.GUI.Datenerhebung.AnamneseBiografie.dsAnamneseBiografie2.Anamnese_BiografieRow row = dsAnamneseBiografie1.Anamnese_Biografie.NewAnamnese_BiografieRow();
            row.ID = Guid.NewGuid();
            row.IDPatient = IDPatient;
            row.IDBenutzer = ENV.USERID;
            row.ErstelltAm = DateTime.Now;
            dsAnamneseBiografie1.Anamnese_Biografie.AddAnamnese_BiografieRow (row);
            return row;
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            //DataBase.Update(daAnamneseKrohwinkel, dsAnamneseKrohwinkel1);
        }
    }
}
