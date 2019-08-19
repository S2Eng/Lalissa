using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using PMDS.Data.Patient;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.DB.Patient
{


    public partial class DBPDXAnamnese : Component
    {

        public DBPDXAnamnese()
        {
            InitializeComponent();
        }

        public DBPDXAnamnese(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }





        public dsPDXAnamnese.PDXAnamneseDataTable PDXAnamneseDataTable
        {
            get { return dsPDXAnamnese1.PDXAnamnese; }
        }

        public void Read()
        {
            dsPDXAnamnese1.PDXAnamnese.Clear();
            RBU.DataBase.Fill(daPDXAnamnese, dsPDXAnamnese1);
        }

        public void ReadByModell(PflegeModelle modell)
        {
            dsPDXAnamnese1.PDXAnamnese.Clear();
            daPDXAnamneseByModell.SelectCommand.Parameters[0].Value = modell.ToString();
            RBU.DataBase.Fill(daPDXAnamneseByModell, dsPDXAnamnese1);
        }

        public dsPDXAnamnese.PDXAnamneseRow New()
        {
            dsPDXAnamnese.PDXAnamneseRow row = dsPDXAnamnese1.PDXAnamnese.NewPDXAnamneseRow();
            row.ID = Guid.NewGuid();
            
            dsPDXAnamnese1.PDXAnamnese.AddPDXAnamneseRow(row);
            return row;
        }

        //Änderung nach 11.05.2007 MDA
        public void NewPDXAnamnese(PflegeModelle modell, int Modellgruppe, Guid IDAnamnese, Guid IDPDX, string Resourceklient)
        {
            dsPDXAnamnese.PDXAnamneseRow row = dsPDXAnamnese1.PDXAnamnese.NewPDXAnamneseRow();
            row.ID = Guid.NewGuid();
            row.Modell = modell.ToString();

            row.Modellgruppe = Modellgruppe;
            row.IDPDX = IDPDX;
            row.Resourceklient = Resourceklient;

            switch (modell)
            {
                case PflegeModelle.Krohwinkel:
                    row.IDAnamneseKrohwinkel = IDAnamnese;
                    break;
                case PflegeModelle.Orem:
                    row.IDAnamneseOrem = IDAnamnese;
                    break;
                case PflegeModelle.Juchli:
                    row.IDAnamneseJuchli = IDAnamnese;
                    break;
                case PflegeModelle.Nanda:
                    row.IDAnamneseNanda = IDAnamnese;
                    break;
                case PflegeModelle.RAI:
                    row.IDAnamneseRAI = IDAnamnese;
                    break;
                case PflegeModelle.RT:
                    row.IDAnamneseRT = IDAnamnese;
                    break;
                case PflegeModelle.POP:
                    row.IDAnamnesePOP = IDAnamnese;
                    break;
            }
 
            dsPDXAnamnese1.PDXAnamnese.AddPDXAnamneseRow(row);
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            RBU.DataBase.Update(daPDXAnamnese, dsPDXAnamnese1);
        }

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Lifert alle vorhandene Pflegeanamnesen zurück
        /// </summary>
        //----------------------------------------------------------------------------------------------
        public dsIDTextBezeichnung GetAllAnamnesen(Guid IDPatient)
        {
            //Änderung nach 25.06.2007 MDA
            dsIDTextBezeichnung1._Table.Clear();
            daAnamnesen.SelectCommand.Parameters[0].Value = IDPatient;  //Krohwinkel
            daAnamnesen.SelectCommand.Parameters[1].Value = IDPatient;  //Orem
            daAnamnesen.SelectCommand.Parameters[2].Value = IDPatient;  //POP

            RBU.DataBase.Fill(daAnamnesen, dsIDTextBezeichnung1._Table);
            return dsIDTextBezeichnung1;
        }

        private void daPDXAnamneseByModell_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {

        }

        private void daAnamnesen_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {

        }

        private void oleDbConnection1_InfoMessage(object sender, OleDbInfoMessageEventArgs e)
        {

        }
    }
}
